using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestMobile.Model
{
    [DataContract]
    public class Penalty
    {
        [DataMember]
        public UInt64 PenaltyId { get; set; }

        [DataMember]
        public long IssuerId { get; set; }

        [DataMember]
        public long DriverOwnerId { get; set; }

        [DataMember]
        public DateTime IssuedDateTime { get; set; }

        [DataMember]
        public DateTime HappenedDateTime { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Description { get; set; }


        [DataMember]
        public string Disagreement { get; set; }

        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longtitude { get; set; }


    }
}
