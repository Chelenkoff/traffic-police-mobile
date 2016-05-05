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
            //Ne6ta za purvona4alna inicializacia
            _welcomeMessage = "Zdravei";
            //
            base.Start();
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; RaisePropertyChanged(() => WelcomeMessage);  }
        }

        public ICommand HiCommand
        {
            get { return new DelegateCommand(sayHi); }
        }

        private void sayHi()
        {
            WelcomeMessage = "Hi";

        }
    }
}
