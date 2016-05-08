using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
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
                    //ShowViewModel<NavigationViewModel>(User);
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
            //IsLoginAvailable = false;
            //IsClearAvailable = false;

        }
        private void stopLoading()
        {
            IsProgressRingVisible = false;
            //IsLoginAvailable = true;
            //IsClearAvailable = true;

        }



    }
}
