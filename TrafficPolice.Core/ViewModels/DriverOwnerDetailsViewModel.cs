using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.Utilities;
using TrafficPolice.Core.TrafficPoliceServiceReference;

using static TrafficPolice.Core.Utilities.DriverOwnerDetailsVMParams;
using System.ServiceModel;

namespace TrafficPolice.Core.ViewModels
{
    public class DriverOwnerDetailsViewModel : MvxViewModel
    {



        private long _userId;
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
            Categories = new List<CategoryItem>();

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

            //A1
            DriverOwner.Categories.a1AcquiryDate = drOwnerParams.a1AcquiryDate;
            DriverOwner.Categories.a1ExpiryDate = drOwnerParams.a1ExpiryDate;
            DriverOwner.Categories.a1Restrictions = drOwnerParams.a1Restrictions;


            Categories.Add( new CategoryItem("A1", drOwnerParams.a1AcquiryDate,
                                              drOwnerParams.a1ExpiryDate, drOwnerParams.a1Restrictions) );

            //A
            DriverOwner.Categories.aAcquiryDate = drOwnerParams.aAcquiryDate;
            DriverOwner.Categories.aExpiryDate = drOwnerParams.aExpiryDate;
            DriverOwner.Categories.aRestrictions = drOwnerParams.aRestrictions;

            Categories.Add(new CategoryItem("A", drOwnerParams.aAcquiryDate,
                                              drOwnerParams.aExpiryDate, drOwnerParams.aRestrictions));

            //B1
            DriverOwner.Categories.b1AcquiryDate = drOwnerParams.b1AcquiryDate;
            DriverOwner.Categories.b1ExpiryDate = drOwnerParams.b1ExpiryDate;
            DriverOwner.Categories.b1Restrictions = drOwnerParams.b1Restrictions;

            Categories.Add(new CategoryItem("B1", drOwnerParams.b1AcquiryDate,
                                              drOwnerParams.b1ExpiryDate, drOwnerParams.b1Restrictions));

            //B
            DriverOwner.Categories.bAcquiryDate = drOwnerParams.bAcquiryDate;
            DriverOwner.Categories.bExpiryDate = drOwnerParams.bAcquiryDate;
            DriverOwner.Categories.bRestrictions = drOwnerParams.bRestrictions;

            Categories.Add(new CategoryItem("B", drOwnerParams.bAcquiryDate,
                                              drOwnerParams.bExpiryDate, drOwnerParams.bRestrictions));

            //C1
            DriverOwner.Categories.c1AcquiryDate = drOwnerParams.c1AcquiryDate;
            DriverOwner.Categories.c1ExpiryDate = drOwnerParams.c1AcquiryDate;
            DriverOwner.Categories.c1Restrictions = drOwnerParams.c1Restrictions;

            Categories.Add(new CategoryItem("C1", drOwnerParams.c1AcquiryDate,
                                              drOwnerParams.c1ExpiryDate, drOwnerParams.c1Restrictions));

            //C
            DriverOwner.Categories.cAcquiryDate = drOwnerParams.cAcquiryDate;
            DriverOwner.Categories.cExpiryDate = drOwnerParams.cAcquiryDate;
            DriverOwner.Categories.cRestrictions = drOwnerParams.cRestrictions;

            Categories.Add(new CategoryItem("C", drOwnerParams.cAcquiryDate,
                                              drOwnerParams.cExpiryDate, drOwnerParams.cRestrictions));

            //D1
            DriverOwner.Categories.d1AcquiryDate = drOwnerParams.d1AcquiryDate;
            DriverOwner.Categories.d1ExpiryDate = drOwnerParams.d1AcquiryDate;
            DriverOwner.Categories.d1Restrictions = drOwnerParams.d1Restrictions;

            Categories.Add(new CategoryItem("D1", drOwnerParams.d1AcquiryDate,
                                              drOwnerParams.d1ExpiryDate, drOwnerParams.d1Restrictions));

            //D
            DriverOwner.Categories.dAcquiryDate = drOwnerParams.dAcquiryDate;
            DriverOwner.Categories.dExpiryDate = drOwnerParams.dAcquiryDate;
            DriverOwner.Categories.dRestrictions = drOwnerParams.dRestrictions;

            Categories.Add(new CategoryItem("D", drOwnerParams.dAcquiryDate,
                                              drOwnerParams.dExpiryDate, drOwnerParams.dRestrictions));

            //BE
            DriverOwner.Categories.beAcquiryDate = drOwnerParams.beAcquiryDate;
            DriverOwner.Categories.beExpiryDate = drOwnerParams.beAcquiryDate;
            DriverOwner.Categories.beRestrictions = drOwnerParams.beRestrictions;

            Categories.Add(new CategoryItem("BE", drOwnerParams.beAcquiryDate,
                                              drOwnerParams.beExpiryDate, drOwnerParams.beRestrictions));

            //C1E
            DriverOwner.Categories.c1eAcquiryDate = drOwnerParams.c1eAcquiryDate;
            DriverOwner.Categories.c1eExpiryDate = drOwnerParams.c1eAcquiryDate;
            DriverOwner.Categories.c1eRestrictions = drOwnerParams.c1eRestrictions;

            Categories.Add(new CategoryItem("C1E", drOwnerParams.c1eAcquiryDate,
                                              drOwnerParams.c1eExpiryDate, drOwnerParams.c1eRestrictions));

            //CE
            DriverOwner.Categories.ceAcquiryDate = drOwnerParams.ceAcquiryDate;
            DriverOwner.Categories.ceExpiryDate = drOwnerParams.ceAcquiryDate;
            DriverOwner.Categories.ceRestrictions = drOwnerParams.ceRestrictions;

            Categories.Add(new CategoryItem("CE", drOwnerParams.ceAcquiryDate,
                                              drOwnerParams.ceExpiryDate, drOwnerParams.ceRestrictions));

            //D1E
            DriverOwner.Categories.d1eAcquiryDate = drOwnerParams.d1eAcquiryDate;
            DriverOwner.Categories.d1eExpiryDate = drOwnerParams.d1eAcquiryDate;
            DriverOwner.Categories.d1eRestrictions = drOwnerParams.d1eRestrictions;

            Categories.Add(new CategoryItem("D1E", drOwnerParams.d1eAcquiryDate,
                                              drOwnerParams.d1eExpiryDate, drOwnerParams.d1eRestrictions));

            //DE
            DriverOwner.Categories.deAcquiryDate = drOwnerParams.deAcquiryDate;
            DriverOwner.Categories.deExpiryDate = drOwnerParams.deAcquiryDate;
            DriverOwner.Categories.deRestrictions = drOwnerParams.deRestrictions;

            Categories.Add(new CategoryItem("DE", drOwnerParams.deAcquiryDate,
                                              drOwnerParams.deExpiryDate, drOwnerParams.deRestrictions));

            //TTB
            DriverOwner.Categories.ttbAcquiryDate = drOwnerParams.ttbAcquiryDate;
            DriverOwner.Categories.ttbExpiryDate = drOwnerParams.ttbAcquiryDate;
            DriverOwner.Categories.ttbRestrictions = drOwnerParams.ttbRestrictions;

            Categories.Add(new CategoryItem("Ттб", drOwnerParams.ttbAcquiryDate,
                                              drOwnerParams.ttbExpiryDate, drOwnerParams.ttbRestrictions));

            //TTM
            DriverOwner.Categories.ttmAcquiryDate = drOwnerParams.ttmAcquiryDate;
            DriverOwner.Categories.ttmExpiryDate = drOwnerParams.ttmAcquiryDate;
            DriverOwner.Categories.ttmRestrictions = drOwnerParams.ttmRestrictions;

            Categories.Add(new CategoryItem("Ттм", drOwnerParams.ttmAcquiryDate,
                                              drOwnerParams.ttmExpiryDate, drOwnerParams.ttmRestrictions));


            //TKT
            DriverOwner.Categories.tktAcquiryDate = drOwnerParams.tktAcquiryDate;
            DriverOwner.Categories.tktExpiryDate = drOwnerParams.tktAcquiryDate;
            DriverOwner.Categories.tktRestrictions = drOwnerParams.tktRestrictions;

            Categories.Add(new CategoryItem("Ткт", drOwnerParams.tktAcquiryDate,
                                              drOwnerParams.tktExpiryDate, drOwnerParams.tktRestrictions));

            //M
            DriverOwner.Categories.mAcquiryDate = drOwnerParams.mAcquiryDate;
            DriverOwner.Categories.mExpiryDate = drOwnerParams.mAcquiryDate;
            DriverOwner.Categories.mRestrictions = drOwnerParams.mRestrictions;

            Categories.Add(new CategoryItem("M", drOwnerParams.mAcquiryDate,
                                              drOwnerParams.mExpiryDate, drOwnerParams.mRestrictions));
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

        private List<CategoryItem> _categories;
        public List<CategoryItem> Categories
        {
            get { return _categories; }
            set { _categories = value; RaisePropertyChanged(() => Categories); }
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
