using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Model
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public bool IsTrafficPoliceman { get; set; }
        public string UserPassword { get; set; }
    }
}
