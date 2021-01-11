using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Core.Models
{
    public class Applicant
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
