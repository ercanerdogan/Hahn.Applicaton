using Hahn.ApplicatonProcess.December2020.API.DTOs;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.SwaggerExamples.Responses
{
    public class ApplicantDtoResponseExample : IExamplesProvider<ApplicantDto>
    {
        public ApplicantDto GetExamples()
        {
            return new ApplicantDto
            {
                Id = 0,
                Name = "FirstName",
                FamilyName = "LastName",
                Address = "address",
                CountyOfOrigin = "country",
                EmailAddress = "@",
                Age = 0,
                Hired = false
            };
        }
    }
}
