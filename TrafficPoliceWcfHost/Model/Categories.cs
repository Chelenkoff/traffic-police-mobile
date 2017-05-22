using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPoliceWcfHost.Model
{
    [DataContract]
    public class Categories
    {
        private DateTime defaultDateTime = Convert.ToDateTime("01/01/0001");

        [DataMember]
        public DateTime a1AcquiryDate { get; set; }
        [DataMember]
        public DateTime a1ExpiryDate { get; set; }
        [DataMember]
        public string a1Restrictions { get; set; }

        [DataMember]
        public DateTime aAcquiryDate { get; set; }
        [DataMember]
        public DateTime aExpiryDate { get; set; }
        [DataMember]
        public string aRestrictions { get; set; }

        [DataMember]
        public DateTime b1AcquiryDate { get; set; }
        [DataMember]
        public DateTime b1ExpiryDate { get; set; }
        [DataMember]
        public string b1Restrictions { get; set; }

        [DataMember]
        public DateTime bAcquiryDate { get; set; }
        [DataMember]
        public DateTime bExpiryDate { get; set; }
        [DataMember]
        public string bRestrictions { get; set; }

        [DataMember]
        public DateTime c1AcquiryDate { get; set; }
        [DataMember]
        public DateTime c1ExpiryDate { get; set; }
        [DataMember]
        public string c1Restrictions { get; set; }

        [DataMember]
        public DateTime cAcquiryDate { get; set; }
        [DataMember]
        public DateTime cExpiryDate { get; set; }
        [DataMember]
        public string cRestrictions { get; set; }

        [DataMember]
        public DateTime d1AcquiryDate { get; set; }
        [DataMember]
        public DateTime d1ExpiryDate { get; set; }
        [DataMember]
        public string d1Restrictions { get; set; }

        [DataMember]
        public DateTime dAcquiryDate { get; set; }
        [DataMember]
        public DateTime dExpiryDate { get; set; }
        [DataMember]
        public string dRestrictions { get; set; }

        [DataMember]
        public DateTime beAcquiryDate { get; set; }
        [DataMember]
        public DateTime beExpiryDate { get; set; }
        [DataMember]
        public string beRestrictions { get; set; }

        [DataMember]
        public DateTime c1eAcquiryDate { get; set; }
        [DataMember]
        public DateTime c1eExpiryDate { get; set; }
        [DataMember]
        public string c1eRestrictions { get; set; }

        [DataMember]
        public DateTime ceAcquiryDate { get; set; }
        [DataMember]
        public DateTime ceExpiryDate { get; set; }
        [DataMember]
        public string ceRestrictions { get; set; }

        [DataMember]
        public DateTime d1eAcquiryDate { get; set; }
        [DataMember]
        public DateTime d1eExpiryDate { get; set; }
        [DataMember]
        public string d1eRestrictions { get; set; }

        [DataMember]
        public DateTime deAcquiryDate { get; set; }
        [DataMember]
        public DateTime deExpiryDate { get; set; }
        [DataMember]
        public string deRestrictions { get; set; }

        [DataMember]
        public DateTime ttbAcquiryDate { get; set; }
        [DataMember]
        public DateTime ttbExpiryDate { get; set; }
        [DataMember]
        public string ttbRestrictions { get; set; }

        [DataMember]
        public DateTime ttmAcquiryDate { get; set; }
        [DataMember]
        public DateTime ttmExpiryDate { get; set; }
        [DataMember]
        public string ttmRestrictions { get; set; }

        [DataMember]
        public DateTime tktAcquiryDate { get; set; }
        [DataMember]
        public DateTime tktExpiryDate { get; set; }
        [DataMember]
        public string tktRestrictions { get; set; }

        [DataMember]
        public DateTime mAcquiryDate { get; set; }
        [DataMember]
        public DateTime mExpiryDate { get; set; }
        [DataMember]
        public string mRestrictions { get; set; }


        public Categories()
        {
            a1AcquiryDate = defaultDateTime;
            a1ExpiryDate = defaultDateTime;
            a1Restrictions = "";

            aAcquiryDate = defaultDateTime;
            aExpiryDate = defaultDateTime;
            aRestrictions = "";

            b1AcquiryDate = defaultDateTime;
            b1ExpiryDate = defaultDateTime;
            b1Restrictions = "";

            bAcquiryDate = defaultDateTime;
            bExpiryDate = defaultDateTime;
            bRestrictions = "";

            c1AcquiryDate = defaultDateTime;
            c1ExpiryDate = defaultDateTime;
            c1Restrictions = "";

            cAcquiryDate = defaultDateTime;
            cExpiryDate = defaultDateTime;
            cRestrictions = "";

            d1AcquiryDate = defaultDateTime;
            d1ExpiryDate = defaultDateTime;
            d1Restrictions = "";

            dAcquiryDate = defaultDateTime;
            dExpiryDate = defaultDateTime;
            dRestrictions = "";

            beAcquiryDate = defaultDateTime;
            beExpiryDate = defaultDateTime;
            beRestrictions = "";

            c1eAcquiryDate = defaultDateTime;
            c1eExpiryDate = defaultDateTime;
            c1eRestrictions = "";

            ceAcquiryDate = defaultDateTime;
            ceExpiryDate = defaultDateTime;
            ceRestrictions = "";

            d1eAcquiryDate = defaultDateTime;
            d1eExpiryDate = defaultDateTime;
            d1eRestrictions = "";

            deAcquiryDate = defaultDateTime;
            deExpiryDate = defaultDateTime;
            deRestrictions = "";

            ttbAcquiryDate = defaultDateTime;
            ttbExpiryDate = defaultDateTime;
            ttbRestrictions = "";

            ttmAcquiryDate = defaultDateTime;
            ttmExpiryDate = defaultDateTime;
            ttmRestrictions = "";

            tktAcquiryDate = defaultDateTime;
            tktExpiryDate = defaultDateTime;
            tktRestrictions = "";

            mAcquiryDate = defaultDateTime;
            mExpiryDate = defaultDateTime;
            mRestrictions = "";

        }
    }
}
