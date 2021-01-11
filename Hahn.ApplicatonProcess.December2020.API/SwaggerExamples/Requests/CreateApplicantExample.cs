using Hahn.ApplicatonProcess.December2020.API.DTOs;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.SwaggerExamples.Requests
{
    public class CreateApplicantExample : IExamplesProvider<ApplicantDto>
    {
        public ApplicantDto GetExamples()
        {
            return new ApplicantDto
            {
                Id = 0,
                Name = "FirstName",
                FamilyName = "LastName",
                Address = "address is a valid address for testing validation",
                CountyOfOrigin = "Turkey",
                EmailAddress = "ercanerdogan@gmail.com",
                Age = 25,
                Hired = false
            };
        }
    }
}
