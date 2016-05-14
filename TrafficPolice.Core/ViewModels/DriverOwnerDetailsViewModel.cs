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
    public class DriverOwnerDetailsViewModel : MvxViewModel
    {
        private  long _userId;
        public DriverOwnerDetailsViewModel()
        {

        }
        public override void Start()
        {
            Title = string.Format("Водач с ЕГН: {0}", DriverOwner.DriverOwnerId);
            base.Start();
        }

        public void Init(DriverOwnerDetailsVMParams drOwnerParams)
        {
            _userId = drOwnerParams.UserId;

            DriverOwner = new DriverOwner();
            DriverOwner.Categories = new Categories();
            DriverOwner.DriverOwnerId = drOwnerParams.DriverOwnerId;
            DriverOwner.FirstName = drOwnerParams.FirstName;
            DriverOwner.SecondName = drOwnerParams.SecondName;
            DriverOwner.LastName = drOwnerParams.LastName;
            DriverOwner.Sex = drOwnerParams.Sex == SexEnum.Man ? Sex.Man : Sex.Woman;
            DriverOwner.Nationality = drOwnerParams.Nationality;
            DriverOwner.BirthDate = drOwnerParams.BirthDate;
            DriverOwner.BirthPlace = drOwnerParams.BirthPlace;
            DriverOwner.Residence = drOwnerParams.Residence;
            DriverOwner.TelNum = drOwnerParams.TelNum;
            DriverOwner.Email = drOwnerParams.Email;
            DriverOwner.RemainingPts = drOwnerParams.RemainingPts;
            DriverOwner.LicenceIssueDate = drOwnerParams.LicenceIssueDate;
            DriverOwner.LicenceExpiryDate = drOwnerParams.LicenceExpiryDate;
            DriverOwner.LicenceIssuedBy = drOwnerParams.LicenceIssuedBy;

            DriverOwner.Categories.a1AcquiryDate = drOwnerParams.a1AcquiryDate;
             DriverOwner.Categories.a1ExpiryDate = drOwnerParams.a1ExpiryDate;
             DriverOwner.Categories.a1Restrictions = drOwnerParams.a1Restrictions;

             DriverOwner.Categories.aAcquiryDate = drOwnerParams.aAcquiryDate;
             DriverOwner.Categories.aExpiryDate = drOwnerParams.aExpiryDate;
               DriverOwner.Categories.aRestrictions = drOwnerParams.aRestrictions;

               DriverOwner.Categories.b1AcquiryDate = drOwnerParams.b1AcquiryDate;
                DriverOwner.Categories.b1ExpiryDate = drOwnerParams.b1ExpiryDate;
                    DriverOwner.Categories.b1Restrictions = drOwnerParams.b1Restrictions;

                   DriverOwner.Categories.bAcquiryDate = drOwnerParams.bAcquiryDate;
                   DriverOwner.Categories.bExpiryDate = drOwnerParams.bAcquiryDate;
                    DriverOwner.Categories.bRestrictions = drOwnerParams.bRestrictions;

                    DriverOwner.Categories.c1AcquiryDate = drOwnerParams.c1AcquiryDate;
                    DriverOwner.Categories.c1ExpiryDate = drOwnerParams.c1AcquiryDate;
                    DriverOwner.Categories.c1Restrictions = drOwnerParams.c1Restrictions;

                      DriverOwner.Categories.cAcquiryDate = drOwnerParams.cAcquiryDate;
                     DriverOwner.Categories.cExpiryDate = drOwnerParams.cAcquiryDate;
                     DriverOwner.Categories.cRestrictions = drOwnerParams.cRestrictions;

                 DriverOwner.Categories.d1AcquiryDate = drOwnerParams.d1AcquiryDate;
                DriverOwner.Categories.d1ExpiryDate = drOwnerParams.d1AcquiryDate;
               DriverOwner.Categories.d1Restrictions = drOwnerParams.d1Restrictions;

                DriverOwner.Categories.dAcquiryDate = drOwnerParams.dAcquiryDate;
               DriverOwner.Categories.dExpiryDate = drOwnerParams.dAcquiryDate;
               DriverOwner.Categories.dRestrictions = drOwnerParams.dRestrictions;

                 DriverOwner.Categories.beAcquiryDate = drOwnerParams.beAcquiryDate;
                 DriverOwner.Categories.beExpiryDate = drOwnerParams.beAcquiryDate;
               DriverOwner.Categories.beRestrictions = drOwnerParams.beRestrictions;

                DriverOwner.Categories.c1eAcquiryDate = drOwnerParams.c1eAcquiryDate;
                DriverOwner.Categories.c1eExpiryDate = drOwnerParams.c1eAcquiryDate;
                DriverOwner.Categories.c1eRestrictions = drOwnerParams.c1eRestrictions;

                   DriverOwner.Categories.ceAcquiryDate = drOwnerParams.ceAcquiryDate;
                   DriverOwner.Categories.ceExpiryDate = drOwnerParams.ceAcquiryDate;
                   DriverOwner.Categories.ceRestrictions = drOwnerParams.ceRestrictions;

                 DriverOwner.Categories.d1eAcquiryDate = drOwnerParams.d1eAcquiryDate;
                  DriverOwner.Categories.d1eExpiryDate = drOwnerParams.d1eAcquiryDate;
                  DriverOwner.Categories.d1eRestrictions = drOwnerParams.d1eRestrictions;

                   DriverOwner.Categories.deAcquiryDate = drOwnerParams.deAcquiryDate;
                   DriverOwner.Categories.deExpiryDate = drOwnerParams.deAcquiryDate;
                   DriverOwner.Categories.deRestrictions = drOwnerParams.deRestrictions;

                     DriverOwner.Categories.ttbAcquiryDate = drOwnerParams.ttbAcquiryDate;
                    DriverOwner.Categories.ttbExpiryDate = drOwnerParams.ttbAcquiryDate;
                    DriverOwner.Categories.ttbRestrictions = drOwnerParams.ttbRestrictions;

                DriverOwner.Categories.ttmAcquiryDate = drOwnerParams.ttmAcquiryDate;
                DriverOwner.Categories.ttmExpiryDate = drOwnerParams.ttmAcquiryDate;
                DriverOwner.Categories.ttmRestrictions = drOwnerParams.ttmRestrictions;

                 DriverOwner.Categories.tktAcquiryDate = drOwnerParams.tktAcquiryDate;
                 DriverOwner.Categories.tktExpiryDate = drOwnerParams.tktAcquiryDate;
                  DriverOwner.Categories.tktRestrictions = drOwnerParams.tktRestrictions;

                  DriverOwner.Categories.mAcquiryDate = drOwnerParams.mAcquiryDate;
                  DriverOwner.Categories.mExpiryDate = drOwnerParams.mAcquiryDate;
                  DriverOwner.Categories.mRestrictions = drOwnerParams.mRestrictions;
        }


        public ICommand CreatePenaltyForDriverCommand
        {
            get { return new DelegateCommand(createPenaltyForDriver); }
        }
        private void createPenaltyForDriver()
        {
            ShowViewModel<AddPenaltyViewModel>(new PenaltyVMParams()
            {
                DriverOwnerID = DriverOwner.DriverOwnerId,
                IssuerID = _userId
            });
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
    }
}
