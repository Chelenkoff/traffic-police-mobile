using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.TrafficPoliceServiceReference;
using TrafficPolice.Core.Utilities;
using static TrafficPolice.Core.Utilities.DriverOwnerDetailsVMParams;

namespace TrafficPolice.Core.ViewModels
{
    public class RegistrationDetailsViewModel : MvxViewModel
    {
       TrafficPoliceServiceClient client;

        public RegistrationDetailsViewModel()
        {
            client = new TrafficPoliceServiceClient();
            client.GetDriverOwnerByIdCompleted += client_GetDriverOwnerByIdCompleted;

        }

        void client_GetDriverOwnerByIdCompleted(object sender, GetDriverOwnerByIdCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                DriverOwner = new DriverOwner();
                DriverOwner = e.Result;



                    ShowViewModel<DriverOwnerDetailsViewModel>(new DriverOwnerDetailsVMParams()
                    {
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


                stopLoading();

            }

        }

        public override void Start()
        {
            Title = string.Format("Рег. номер: {0}", Registration.RegNum);
            base.Start();
        }

        public void Init(Registration reg)
        {
            Registration  = reg;
            // use the parameters here
        }


        private Registration _registration;
        public Registration Registration
        {
            get { return _registration; }
            set { _registration = value; RaisePropertyChanged(() => Registration); }
        }


        private DriverOwner _driverOwner;
        public DriverOwner DriverOwner
        {
            get { return _driverOwner; }
            set { _driverOwner = value; RaisePropertyChanged(() => DriverOwner); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }


        public ICommand ShowDriverOwnerCommand
        {
            get { return new DelegateCommand(showDriverOwner); }
        }
        private void showDriverOwner()
        {
            startLoading();
            client.GetDriverOwnerByIdAsync(Registration.DriverOwnerId.ToString());
            
        }

        private void startLoading()
        {
            IsProgressRingVisible = true;
        }
        private void stopLoading()
        {
            IsProgressRingVisible = false;
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


    }
}
