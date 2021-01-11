using FluentValidation;
using Hahn.ApplicatonProcess.December2020.API.DTOs;
using System.Net.Http;
using System.Threading.Tasks;
//using Hahn.ApplicatonProcess.December2020.API.ExternalServices;


namespace Hahn.ApplicatonProcess.December2020.API.Validators
{
    public class ApplicantDtoValidator : AbstractValidator<ApplicantDto>
    {
        private readonly HttpClient _httpClient;

        public ApplicantDtoValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;

            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FamilyName).MinimumLength(5);
            RuleFor(x => x.Address).MinimumLength(10);

            RuleFor(x => x.CountyOfOrigin).MustAsync(async (appDto, context, cancellation) =>
            {
                return await CheckCountryValidation(appDto);
            }).WithMessage(app=> $"'{app.CountyOfOrigin}' is not a valid country");

            RuleFor(x => x.Age).ExclusiveBetween(20, 60);
            RuleFor(x => x.Hired).NotNull();
            RuleFor(x => x.EmailAddress).EmailAddress(); //this is not good enough validation. for ex : q@q..com is domain address consist of two dot. this rule couldn't catch this misusage

            RuleFor(x => x.EmailAddress).Matches(expression: @"[a-z0 - 9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            //check for this regex here - > https://regexr.com/2rhq7


            //RuleFor(x => x.EmailAddress).Matches(expression: @"^([\w-]|(?<!\.)\.)+[a-zA-Z0-9]@[a-zA-Z0-9]([a-zA-Z0-9\-]+)((\.([a-zA-Z]){2,9}){0‌​,2})$");
            //check for this regex here - > https://regex101.com/r/nD5fC9/1


        }


        private async Task<bool> CheckCountryValidation(ApplicantDto arg)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.eu/rest/v2/name/{arg.CountyOfOrigin}?fullText=true");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
