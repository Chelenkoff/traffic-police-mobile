using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.ViewModels
{
    public class NavigationViewModel : MvxViewModel
    {
        public NavigationViewModel()
        {
            DriverOwnerChildVM = new DriverOwnerChildViewModel();
            RegistrationChildVM = new RegistrationChildViewModel();
            PenaltyChildVM = new PenaltyChildViewModel();
        }

        public override void Start()
        {
           base.Start();
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
