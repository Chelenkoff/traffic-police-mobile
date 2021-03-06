﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.Utilities;
using System.ServiceModel;
using TrafficPolice.Core.TrafficPoliceServiceReference;

namespace TrafficPolice.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
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


        public LoginViewModel()
        {

            BasicHttpBinding binding = CreateBasicHttp();

            client = new TrafficPoliceServiceClient(binding,EndPoint);
            
        }

        public override void Start()
        {

            client.GetUserByIdAndPassCompleted += client_GetUserByIdAndPassCompleted;

            //TODO uncomment in debug
            Password = "qwerty";
            UserId = "4";

            stopLoading();
                       
            
            base.Start();
        }


        void client_GetUserByIdAndPassCompleted(object sender, GetUserByIdAndPassCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                User = e.Result;

                if (dbResponseValidation(User))
                {

                    ShowViewModel<NavigationViewModel>(User);

                }
            }
            stopLoading();

        }


        public ICommand LoginCommand
        {
            get { return new DelegateCommand(login); }
        }

        private void login()
        {
            clearInfoMessage();

            if (!uiPassAndIdValidation(Password, UserId)) return;

            startLoading();
            client.GetUserByIdAndPassAsync(UserId, Password);
                       
        }

        public ICommand ClearCommand
        {
            get { return new DelegateCommand(clearFields); }
        }

        private void clearFields()
        {

            UserId = string.Empty;
            Password = string.Empty;
            clearInfoMessage();
         }


        private bool dbResponseValidation(User usr)
        {
            //DB-OK , USER - NOT FOUND
            if (usr != null && usr.UserId == 0)
            {
                WarningType = "Грешка";
                WarningMessage = "Не съществува потребител с тези данни!";
                return false;
            }

            //DB - NOT CONNECTED
            else if (usr == null)
            {
                WarningType = "Грешка";
                WarningMessage = "Проблем с връзката с базата данни.";
                return false;
            }
            else return true;

        }

        private bool uiPassAndIdValidation(string pass, string id)
        {
            //Null or whitespaces
            if (String.IsNullOrWhiteSpace(pass) || String.IsNullOrWhiteSpace(id))
            {
                WarningType = "Внимание";
                WarningMessage = "Не са въведени необходимите данни!";
                return false;
            }
            //Digit check
            else if (!IsDigitsOnly(id))
            {
                WarningType = "Внимание";
                WarningMessage = "Некоректен формат на 'Служебен номер'! \nМоже да съдържа само цифри!";
                return false;
            }

            else return true;
        }

        //Password property
        private string _password;
        public string Password
        {
            private get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
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

        //IsLoginAvailable property
        private bool _isLoginAvailable;
        public bool IsLoginAvailable
        {
            get { return _isLoginAvailable; }
            set
            {
                _isLoginAvailable = value;
                RaisePropertyChanged(() => IsLoginAvailable);
            }
        }

        //IsClearAvailable property
        private bool _isClearAvailable;
        public bool IsClearAvailable
        {
            get { return _isClearAvailable; }
            set
            {
                _isClearAvailable = value;
                RaisePropertyChanged(() => IsClearAvailable);
            }
        }



        private User _user;
        public User User
        {
            private get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }


        //UserId property
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged(() => UserId);
            }
        }


        private void startLoading()
        {
            IsProgressRingVisible = true;
            IsLoginAvailable = false;
            IsClearAvailable = false;

        }
        private void stopLoading()
        {
            IsProgressRingVisible = false;
            IsLoginAvailable = true;
            IsClearAvailable = true;

        }

        private void clearInfoMessage()
        {
            WarningType = string.Empty;
            WarningMessage = string.Empty;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

    }
}
