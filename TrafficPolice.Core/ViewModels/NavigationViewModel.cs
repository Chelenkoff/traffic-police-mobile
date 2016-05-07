using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.Utilities;

namespace TrafficPolice.Core.ViewModels
{
    public class NavigationViewModel : MvxViewModel
    {
        public NavigationViewModel()
        {
            DriverOwnerChildVM = new DriverOwnerChildViewModel();
            RegistrationChildVM = new RegistrationChildViewModel();
            PenaltyChildVM = new PenaltyChildViewModel();
            WelcomeMessage = "asdadsad";
        }

        public override void Start()
        {
           base.Start();
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; RaisePropertyChanged(() => WelcomeMessage); }
        }

        public ICommand Logout
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }


        private DriverOwnerChildViewModel _driverOwnerChildVM;
        public DriverOwnerChildViewModel DriverOwnerChildVM
        {
            get { return _driverOwnerChildVM; }
            set { _driverOwnerChildVM = value; RaisePropertyChanged(() => DriverOwnerChildVM); }
        }

        private RegistrationChildViewModel _registrationChildVM;
        public RegistrationChildViewModel RegistrationChildVM
        {
            get { return _registrationChildVM; }
            set { _registrationChildVM = value; RaisePropertyChanged(() => RegistrationChildVM); }
        }

        private PenaltyChildViewModel _penaltyChildVM;
        public PenaltyChildViewModel PenaltyChildVM
        {
            get { return _penaltyChildVM; }
            set { _penaltyChildVM = value; RaisePropertyChanged(() => PenaltyChildVM); }
        }



    }
}
