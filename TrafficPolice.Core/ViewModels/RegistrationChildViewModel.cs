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
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.TrafficPoliceServiceReference;
using TrafficPolice.Core.Utilities;
using TrafficPolice.Core.Utilities.OCR;

namespace TrafficPolice.Core.ViewModels
{
    public class RegistrationChildViewModel : MvxViewModel
    {
        TrafficPoliceServiceClient client;

        public static readonly EndpointAddress EndPoint = new EndpointAddress(Utilities.Configuration.Endpoint);

        private static BasicHttpBinding CreateBasicHttp()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }


        private IMvxPictureChooserTask _pictureChooserTask;

        public RegistrationChildViewModel()
        {
            _pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();


            BasicHttpBinding binding = CreateBasicHttp();

            client = new TrafficPoliceServiceClient(binding, EndPoint);

            client.getRegByRegNumCompleted += client_getRegByRegNumCompleted;

            //TODO: delete in release
            RegNum = "KH6666AH";
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
                try
                {
                    var request = new RestRequest(Method.POST);

                    request.AddHeader("apikey", Constants.OCR_API_KEY);
                    request.AddParameter("base64Image", base64Image, ParameterType.GetOrPost);
                    request.AddParameter("language", "bul", ParameterType.GetOrPost);


                    //IRestResponse response = await client.Execute(request);
                    startLoading();

                    IRestResponse<OCRSpaceResponse> response2 = await client.Execute<OCRSpaceResponse>(request);

                    if (response2.Data.IsErroredOnProcessing == true)
                    {
                        WarningType = "Внимание";
                        WarningMessage = "Възникнаха грешки при обработката на изображението.";
                        stopLoading();
                        return;
                    }

                    if (response2.Data.ParsedResults.Count > 0)
                    {
                        switch (response2.Data.ParsedResults.ElementAt(0).FileParseExitCode)
                        {
                            case 0:
                                WarningType = "Внимание";
                                WarningMessage = "Файлът не беше открит.";
                                stopLoading();
                                return;
                            case -10:
                            case -20:
                            case -30:
                            case -99:
                                WarningType = "Внимание";
                                WarningMessage = "Възникна проблем при анализирането на изображението.";
                                stopLoading();
                                return;
                        }

                        //Parsed text
                        string numText = response2.Data.ParsedResults.ElementAt(0).ParsedText;
                        RegNumOCRValidator.validate(ref numText);
                        RegNum = numText;


                    }
                }
                catch (Exception e)
                {

                    WarningType = "Внимание";
                    WarningMessage = "Възникна проблем с OCR услугата.";
                }


            }
            stopLoading();

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

        private void clearRegistrationInfo()
        {
            clearInfoMessage();
            RegNum = string.Empty;
        }

        //Clearing registration input
        private MvxCommand _clearRegistration;
        public ICommand ClearRegistrationCommand
        {
            get
            {
                _clearRegistration = _clearRegistration ?? new MvxCommand(clearRegistrationInfo);
                return _clearRegistration;
            }
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
            try
            {
                clearRegistrationInfo();
                _pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();
                _pictureChooserTask.TakePicture(1000, 100, OnPicture, () => { });
            }
            catch (Exception)
            {

                WarningType = "Внимание";
                WarningMessage = "Възникна проблем при избора на изображение.";
                stopLoading();
            }

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

        public ICommand Logout
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        private void DoChoosePicture()
        {
            try
            {
                clearRegistrationInfo();
                _pictureChooserTask = Mvx.Resolve<IMvxPictureChooserTask>();
                _pictureChooserTask.ChoosePictureFromLibrary(500, 100, OnPicture, () => { });


            }
            catch (Exception)
            {

                WarningType = "Внимание";
                WarningMessage = "Възникна проблем при избора на изображение.";
                stopLoading();
            }

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


            String base64Image = "";
            try
            {
                pictureStream.CopyTo(memoryStream);
                Bytes = memoryStream.ToArray();

                base64Image = "data:image/jpeg;base64," + Convert.ToBase64String(Bytes);

                scanRegistration(base64Image);
            }
            catch (ArgumentNullException)
            {
                WarningType = "Внимание";
                WarningMessage = "Неправилен формат на изображението.";
                stopLoading();
            }

            stopLoading();
        }






    }
}
