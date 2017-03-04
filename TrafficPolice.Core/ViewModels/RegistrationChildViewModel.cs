using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.ServiceReference1;
using TrafficPolice.Core.Utilities;

namespace TrafficPolice.Core.ViewModels
{
    public class RegistrationChildViewModel : MvxViewModel
    {
        Service1Client client;
        public RegistrationChildViewModel()
        {
            client = new Service1Client();
            client.getRegByRegNumCompleted += client_getRegByRegNumCompleted;

        }

        private  IMvxPictureChooserTask _pictureChooserTask;

        public RegistrationChildViewModel(IMvxPictureChooserTask pictureChooserTask)
        {
            client = new Service1Client();
            client.getRegByRegNumCompleted += client_getRegByRegNumCompleted;
            _pictureChooserTask = pictureChooserTask;
        }

        public override void Start()
        {


            stopLoading();

            base.Start();
        }


        void client_getRegByRegNumCompleted(object sender, getRegByRegNumCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Registration = e.Result;

                if (dbResponseValidation(Registration))
                {
                    


                    ShowViewModel<RegistrationDetailsViewModel>(Registration);

                }
                stopLoading();

            }

        }

        private Registration _registration;
        public Registration Registration
        {
            private get { return _registration; }
            set
            {
                _registration = value;
                RaisePropertyChanged(() => Registration);
            }
        }

        //Get/Set RegNum
        private string _regNum;
        public string RegNum
        {
            get { return _regNum; }
            set { _regNum = value; RaisePropertyChanged(() => RegNum); }
        }

        public ICommand ShowRegCommand
        {
            get { return new DelegateCommand(showReg); }
        }
        private void showReg()
        {
            clearInfoMessage();

            if (!uiDataValidation(RegNum)) return;

            client.getRegByRegNumAsync(RegNum);
            startLoading();
        }

        private async void scanRegistration(String base64Image)
        {
            clearInfoMessage();

            using (var client = new RestClient(new Uri(Constants.OCR_API_ENDPOINT)))
            {

                var request = new RestRequest(Method.POST);

                request.AddHeader("apikey", Constants.OCR_API_KEY);
                request.AddParameter("base64Image", base64Image, ParameterType.GetOrPost);

                IRestResponse response = await client.Execute(request);
            }
        }

        private bool uiDataValidation(string regNum)
        {
            //Name validation
            string regNumValidation = InputValidator.validateRegNum(regNum);

            if (regNumValidation != null)
            {
                WarningMessage = regNumValidation;
                WarningType = "Невалиден рег. номер";
                return false;
            }

            return true;
        }

        private bool dbResponseValidation(Registration reg)
        {
            //DB-OK , USER - NOT FOUND
            if (reg != null && reg.RegNum == null)
            {
                WarningType = "Грешка";
                WarningMessage = String.Format("Не съществува регистрация {0}!", _regNum);
                return false;
            }

            //DB - NOT CONNECTED
            else if (reg == null)
            {
                WarningType = "Внимание";
                WarningMessage = "Проблем с връзката с базата данни.";
                return false;
            }
            else return true;

        }

        private void clearInfoMessage()
        {
            WarningType = string.Empty;
            WarningMessage = string.Empty;
        }

        //WarningType property
        private string _warningType;
        public string WarningType
        {
            private get { return _warningType; }
            set
            {
                _warningType = value;
                RaisePropertyChanged(() => WarningType);
            }
        }

        //WarningType property
        private string _warningMessage;
        public string WarningMessage
        {
            private get { return _warningMessage; }
            set
            {
                _warningMessage = value;
                RaisePropertyChanged(() => WarningMessage);
            }
        }

        //IsProgressRingVisible property
        private bool _isProgressRingVisible;
        public bool IsProgressRingVisible
        {
            get { return _isProgressRingVisible; }
            set
            {
                _isProgressRingVisible = value;
                RaisePropertyChanged(() => IsProgressRingVisible);
            }
        }

        private void startLoading()
        {
            IsProgressRingVisible = true;
        }
        private void stopLoading()
        {
            IsProgressRingVisible = false;
        }


        //TESTS
        private MvxCommand _takePictureCommand;
        public ICommand TakePictureCommand
        {
            get
            {
                _takePictureCommand = _takePictureCommand ?? new MvxCommand(DoTakePicture);
                return _takePictureCommand;
            }
        }

        private void DoTakePicture()
        {
            _pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();
            _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
        }

        private MvxCommand _choosePictureCommand;
        public ICommand ChoosePictureCommand
        {
            get
            {
                _choosePictureCommand = _choosePictureCommand ?? new MvxCommand(DoChoosePicture);
                return _choosePictureCommand;
            }
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private byte[] _bytes;
        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }


        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();

            String base64Image = "";
            try
            {
                base64Image = "data:image/jpeg;base64," + Convert.ToBase64String(Bytes);

                scanRegistration(base64Image);
            }
            catch (ArgumentNullException)
            {

            }
        }





    }
}
