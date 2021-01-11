using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.DTOs
{
    public class ErrorDto
    {
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto()
        {
            Errors = new List<string>();

        }
    }
}
