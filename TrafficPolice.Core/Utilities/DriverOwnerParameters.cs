using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities
{
    public class DriverOwnerParameters
    {

        public DriverOwnerParameters()
        {

        }
        public long DriverOwnerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public SexEnum Sex { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Residence { get; set; }
        public string TelNum { get; set; }
        public string Email { get; set; }
        public int RemainingPts { get; set; }
        public DateTime LicenceIssueDate { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public string LicenceIssuedBy { get; set; }

        //Categories params
        public DateTime a1AcquiryDate { get; set; }
        public DateTime a1ExpiryDate { get; set; }
        public string a1Restrictions { get; set; }
        public DateTime aAcquiryDate { get; set; }
        public DateTime aExpiryDate { get; set; }
        public string aRestrictions { get; set; }
        public DateTime b1AcquiryDate { get; set; }
        public DateTime b1ExpiryDate { get; set; }
        public string b1Restrictions { get; set; }
        public DateTime bAcquiryDate { get; set; }
        public DateTime bExpiryDate { get; set; }
        public string bRestrictions { get; set; }
        public DateTime c1AcquiryDate { get; set; }
        public DateTime c1ExpiryDate { get; set; }
        public string c1Restrictions { get; set; }
        public DateTime cAcquiryDate { get; set; }
        public DateTime cExpiryDate { get; set; }
        public string cRestrictions { get; set; }
        public DateTime d1AcquiryDate { get; set; }
        public DateTime d1ExpiryDate { get; set; }
        public string d1Restrictions { get; set; }
        public DateTime dAcquiryDate { get; set; }
        public DateTime dExpiryDate { get; set; }
        public string dRestrictions { get; set; }
        public DateTime beAcquiryDate { get; set; }
        public DateTime beExpiryDate { get; set; }
        public string beRestrictions { get; set; }
        public DateTime c1eAcquiryDate { get; set; }
        public DateTime c1eExpiryDate { get; set; }
        public string c1eRestrictions { get; set; }
        public DateTime ceAcquiryDate { get; set; }
        public DateTime ceExpiryDate { get; set; }
        public string ceRestrictions { get; set; }
        public DateTime d1eAcquiryDate { get; set; }
        public DateTime d1eExpiryDate { get; set; }
        public string d1eRestrictions { get; set; }
        public DateTime deAcquiryDate { get; set; }
        public DateTime deExpiryDate { get; set; }
        public string deRestrictions { get; set; }
        public DateTime ttbAcquiryDate { get; set; }
        public DateTime ttbExpiryDate { get; set; }
        public string ttbRestrictions { get; set; }
        public DateTime ttmAcquiryDate { get; set; }
        public DateTime ttmExpiryDate { get; set; }
        public string ttmRestrictions { get; set; }
        public DateTime tktAcquiryDate { get; set; }
        public DateTime tktExpiryDate { get; set; }
        public string tktRestrictions { get; set; }
        public DateTime mAcquiryDate { get; set; }
        public DateTime mExpiryDate { get; set; }
        public string mRestrictions { get; set; }


        public enum SexEnum
        {

            Man = 'М',
            Woman = 'Ж'

        }
    }
}
