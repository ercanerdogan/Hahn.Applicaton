using System.ComponentModel;

namespace Hahn.ApplicatonProcess.December2020.API.DTOs
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountyOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }

        [DefaultValue(false)]
        public bool Hired { get; set; }


    }
}
