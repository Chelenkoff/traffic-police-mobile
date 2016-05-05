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
    public class LoginViewModel : MvxViewModel
    {
        Service1Client client;
        public LoginViewModel()
        {
            client = new Service1Client();
            
            
            DriverOwner drOwner = new DriverOwner();
            
        }

        public override void Start()
        {

            client.GetUserByIdAndPassCompleted += client_GetUserByIdAndPassCompleted;
            base.Start();
        }

        void client_GetUserByIdAndPassCompleted(object sender, GetUserByIdAndPassCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                User = e.Result;

                if (dbResponseValidation(User))
                {
                    WarningMessage = "Логнах се";
                }

            }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; RaisePropertyChanged(() => WelcomeMessage);  }
        }

        public ICommand LoginCommand
        {
            get { return new DelegateCommand(login); }
        }

        private void login()
        {
            client.GetUserByIdAndPassAsync(UserId, Password);
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

        //Password property
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
    }
}
