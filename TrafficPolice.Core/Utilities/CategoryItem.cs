using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities
{
    public class CategoryItem
    {
        public string Name { get; set; }
        public DateTime AcquiryDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Restrictions { get; set; }

        public CategoryItem(string name, DateTime acquiryDate, DateTime expiryDate, string restrictions)
        {
            Name = name;
            AcquiryDate = acquiryDate;
            ExpiryDate = expiryDate;
            Restrictions = restrictions;
        }

        public void Clear()
        {
            Name = string.Empty;
            AcquiryDate = Convert.ToDateTime("01/01/0001");
            ExpiryDate = Convert.ToDateTime("01/01/0001");
            Restrictions = string.Empty;

        }
    }
}
