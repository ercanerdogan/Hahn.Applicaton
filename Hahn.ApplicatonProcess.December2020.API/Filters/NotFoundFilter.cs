using Hahn.ApplicatonProcess.December2020.API.DTOs;
using Hahn.ApplicatonProcess.December2020.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IApplicantService _applicantService;
        public NotFoundFilter(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var applicant = await _applicantService.GetByIdAsync(id);

            if(applicant != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto
                {
                    StatusCode = 404
                };
                errorDto.Errors.Add($"Applicant not found : id = {id}");

                context.Result = new NotFoundObjectResult(errorDto);
            }

        }
    }
}
