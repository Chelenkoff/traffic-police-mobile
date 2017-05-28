using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficPolice.Core.TrafficPoliceServiceReference;

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



            //PenaltyChildVM = new PenaltyChildViewModel();

        }

        //VM with parameters
        public void Init(User usr)
        {
            User = usr;
            //Passing 'User' to DriverOwnerChildVM
            DriverOwnerChildVM.User = User;
        }

        public override void Start()
        {
            LoginInfo = String.Format("Здравейте, {0} {1}",User.FirstName,User.LastName);
           base.Start();
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { _welcomeMessage = value; RaisePropertyChanged(() => WelcomeMessage); }
        }

        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged(() => User); }
        }

        private string _loginInfo;
        public string LoginInfo
        {
            get { return _loginInfo; }
            set { _loginInfo = value; RaisePropertyChanged(() => LoginInfo); }
        }

        public ICommand Logout
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand CreatePenaltyCommand
        {
            get { return new DelegateCommand(createPenalty); }
        }
        private void createPenalty()
        {

            ShowViewModel<AddPenaltyViewModel>(new PenaltyVMParams()
            {
                IssuerID = User.UserId
            });

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

        //private PenaltyChildViewModel _penaltyChildVM;
        //public PenaltyChildViewModel PenaltyChildVM
        //{
        //    get { return _penaltyChildVM; }
        //    set { _penaltyChildVM = value; RaisePropertyChanged(() => PenaltyChildVM); }
        //}



    }
}
