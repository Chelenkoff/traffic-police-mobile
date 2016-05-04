using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Model
{
    public class Penalty
    {

        public UInt64 PenaltyId { get; set; }
        public long IssuerId { get; set; }
        public long DriverOwnerId { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime HappenedDateTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Disagreement { get; set; }
    }
}
