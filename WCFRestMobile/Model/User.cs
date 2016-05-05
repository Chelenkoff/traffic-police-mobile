using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestMobile.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public bool IsTrafficPoliceman { get; set; }
        [DataMember]
        public string UserPassword { get; set; }


    }
}
