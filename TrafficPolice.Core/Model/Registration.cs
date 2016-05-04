using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Model
{
    public class Registration
    {
        public string RegNum { get; set; }
        public long DriverOwnerId { get; set; }
        public string CarManufacturer { get; set; }
        public string CarModel { get; set; }
        public string CarType { get; set; }
        public string CarColor { get; set; }
        public int CarCubage { get; set; }
        public int CarHp { get; set; }
        public string CarVin { get; set; }
        public DateTime FirstRegDate { get; set; }
        public DateTime RecentRegDate { get; set; }
        public bool HasCivilInsurance { get; set; }
        public string CivilInsurer { get; set; }
        public DateTime? CivilInsuranceStartDate { get; set; }
        public DateTime? CivilInsuranceEndDate { get; set; }
        public bool HasVignette { get; set; }
        public DateTime? VignetteValidUntil { get; set; }
        public bool HasDamageInsurance { get; set; }
        public string DamageInsurer { get; set; }
        public DateTime? DamageInsuranceStartDate { get; set; }
        public DateTime? DamageInsuranceEndDate { get; set; }
    }
}
