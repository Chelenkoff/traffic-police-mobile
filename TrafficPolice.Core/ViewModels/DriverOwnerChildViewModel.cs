using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.ServiceReference1;
using TrafficPolice.Core.Utilities;
using static TrafficPolice.Core.Utilities.DriverOwnerDetailsVMParams;

namespace TrafficPolice.Core.ViewModels
{
    public class DriverOwnerChildViewModel : MvxViewModel
    {
        Service1Client client;
        public DriverOwnerChildViewModel()
        {
  
            client = new Service1Client();
            client.GetDriverOwnerByIdCompleted += client_GetDriverOwnerByIdCompleted;
        }


        void client_GetDriverOwnerByIdCompleted(object sender, GetDriverOwnerByIdCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                DriverOwner = e.Result;

                if (dbResponseValidation(DriverOwner))
                {

                    ShowViewModel<DriverOwnerDetailsViewModel>(new DriverOwnerDetailsVMParams() {
                        UserId = User.UserId,

                        DriverOwnerId = DriverOwner.DriverOwnerId,
                        FirstName = DriverOwner.FirstName,
                        SecondName = DriverOwner.SecondName,
                        LastName = DriverOwner.LastName,
                        Sex = DriverOwner.Sex == Sex.Man ? SexEnum.Man : SexEnum.Woman,
                        Nationality = DriverOwner.Nationality,
                        BirthDate = DriverOwner.BirthDate,
                        BirthPlace = DriverOwner.BirthPlace,
                        Residence = DriverOwner.Residence,
                        TelNum = DriverOwner.TelNum,
                        Email = DriverOwner.Email,
                        RemainingPts = DriverOwner.RemainingPts,
                        LicenceIssueDate = DriverOwner.LicenceIssueDate,
                        LicenceExpiryDate = DriverOwner.LicenceExpiryDate,
                        LicenceIssuedBy = DriverOwner.LicenceIssuedBy,
                        
                        a1AcquiryDate = DriverOwner.Categories.a1AcquiryDate,
                        a1ExpiryDate = DriverOwner.Categories.a1ExpiryDate,
                        a1Restrictions = DriverOwner.Categories.a1Restrictions,

                        aAcquiryDate = DriverOwner.Categories.aAcquiryDate,
                        aExpiryDate = DriverOwner.Categories.aExpiryDate,
                        aRestrictions = DriverOwner.Categories.aRestrictions,

                        b1AcquiryDate = DriverOwner.Categories.b1AcquiryDate,
                        b1ExpiryDate = DriverOwner.Categories.b1ExpiryDate,
                        b1Restrictions = DriverOwner.Categories.b1Restrictions,

                        bAcquiryDate = DriverOwner.Categories.bAcquiryDate,
                        bExpiryDate = DriverOwner.Categories.bAcquiryDate,
                        bRestrictions = DriverOwner.Categories.bRestrictions,

                        c1AcquiryDate = DriverOwner.Categories.c1AcquiryDate,
                        c1ExpiryDate = DriverOwner.Categories.c1AcquiryDate,
                        c1Restrictions = DriverOwner.Categories.c1Restrictions,

                        cAcquiryDate = DriverOwner.Categories.cAcquiryDate,
                        cExpiryDate = DriverOwner.Categories.cAcquiryDate,
                        cRestrictions = DriverOwner.Categories.cRestrictions,

                        d1AcquiryDate = DriverOwner.Categories.d1AcquiryDate,
                        d1ExpiryDate = DriverOwner.Categories.d1AcquiryDate,
                        d1Restrictions = DriverOwner.Categories.d1Restrictions,

                        dAcquiryDate = DriverOwner.Categories.dAcquiryDate,
                        dExpiryDate = DriverOwner.Categories.dAcquiryDate,
                        dRestrictions = DriverOwner.Categories.dRestrictions,

                        beAcquiryDate = DriverOwner.Categories.beAcquiryDate,
                        beExpiryDate = DriverOwner.Categories.beAcquiryDate,
                        beRestrictions = DriverOwner.Categories.beRestrictions,

                        c1eAcquiryDate = DriverOwner.Categories.c1eAcquiryDate,
                        c1eExpiryDate = DriverOwner.Categories.c1eAcquiryDate,
                        c1eRestrictions = DriverOwner.Categories.c1eRestrictions,

                        ceAcquiryDate = DriverOwner.Categories.ceAcquiryDate,
                        ceExpiryDate = DriverOwner.Categories.ceAcquiryDate,
                        ceRestrictions = DriverOwner.Categories.ceRestrictions,

                        d1eAcquiryDate = DriverOwner.Categories.d1eAcquiryDate,
                        d1eExpiryDate = DriverOwner.Categories.d1eAcquiryDate,
                        d1eRestrictions = DriverOwner.Categories.d1eRestrictions,

                        deAcquiryDate = DriverOwner.Categories.deAcquiryDate,
                        deExpiryDate = DriverOwner.Categories.deAcquiryDate,
                        deRestrictions = DriverOwner.Categories.deRestrictions,

                        ttbAcquiryDate = DriverOwner.Categories.ttbAcquiryDate,
                        ttbExpiryDate = DriverOwner.Categories.ttbAcquiryDate,
                        ttbRestrictions = DriverOwner.Categories.ttbRestrictions,

                        ttmAcquiryDate = DriverOwner.Categories.ttmAcquiryDate,
                        ttmExpiryDate = DriverOwner.Categories.ttmAcquiryDate,
                        ttmRestrictions = DriverOwner.Categories.ttmRestrictions,

                        tktAcquiryDate = DriverOwner.Categories.tktAcquiryDate,
                        tktExpiryDate = DriverOwner.Categories.tktAcquiryDate,
                        tktRestrictions = DriverOwner.Categories.tktRestrictions,

                        mAcquiryDate = DriverOwner.Categories.mAcquiryDate,
                        mExpiryDate = DriverOwner.Categories.mAcquiryDate,
                        mRestrictions = DriverOwner.Categories.mRestrictions,


                    });

                }
                stopLoading();

            }

        }



        private DriverOwner _driverOwner;
        public DriverOwner DriverOwner
        {
            private get { return _driverOwner; }
            set
            {
                _driverOwner = value;
                RaisePropertyChanged(() => DriverOwner);
            }
        }

        public override void Start()
        {
            base.Start();
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

        public ICommand ShowDriverOwnerCommand
        {
            get { return new DelegateCommand(showDriverOwner); }
        }
        private void showDriverOwner()
        {
            clearInfoMessage();

            if (!uiDataValidation(ID)) return;

            client.GetDriverOwnerByIdAsync(ID);
            startLoading();
        }

        //Get/Set Id
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(() => ID); }
        }

        private bool uiDataValidation(string egn)
        {
            //ID validation
            string idValidation = InputValidator.validateEGN(egn);

            if (idValidation != null)
            {
                WarningMessage = idValidation;
                WarningType = "Невалидно ЕГН";
                return false;
            }

            return true;
        }

        private bool dbResponseValidation(DriverOwner drOwner)
        {
            //DB-OK , USER - NOT FOUND
            if (drOwner != null && drOwner.DriverOwnerId == 0)
            {
                WarningMessage = "Не съществува водач с тези данни!";
                WarningType = "Грешка";
                return false;
            }

            //DB - NOT CONNECTED
            else if (drOwner == null)
            {
                WarningMessage = "Проблем с връзката с базата данни.";
                WarningType = "Грешка";
                return false;
            }
            else return true;

        }
    }


 }

