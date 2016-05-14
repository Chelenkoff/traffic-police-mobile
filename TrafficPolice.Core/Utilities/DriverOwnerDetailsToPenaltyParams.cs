using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities
{
   public class PenaltyVMParams
    {
        public PenaltyVMParams()
        {

        }

        public long DriverOwnerID { get; set; }
        public long IssuerID { get; set; }
    }
}
