using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Model
{
    public class DriverOwner
    {
        private const string DEFAULT_NATIONALITY = "България";
        private const byte DEFAULT_PTS = 39;

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
        public Categories Categories { get; set; }
        public List<Penalty> Penalties { get; set; }


        //Constructor
        public DriverOwner()
        {
            DriverOwnerId = 0;
            FirstName = string.Empty;
            SecondName = string.Empty;
            LastName = string.Empty;

            Sex = SexEnum.Man;


            Nationality = DEFAULT_NATIONALITY;
            BirthDate = new DateTime(2000, 1, 1);
            BirthPlace = string.Empty;
            Residence = string.Empty;
            TelNum = string.Empty;
            Email = string.Empty;
            RemainingPts = DEFAULT_PTS;
            LicenceIssueDate = DateTime.Now;
            LicenceExpiryDate = LicenceIssueDate.AddYears(10);
            LicenceIssuedBy = string.Empty;

            Categories = new Categories();


        }


    }




    public enum SexEnum
    {

        Man = 'М',
        Woman = 'Ж'

    }
}
