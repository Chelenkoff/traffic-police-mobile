using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        public LoginViewModel()
        {

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
    }
}
