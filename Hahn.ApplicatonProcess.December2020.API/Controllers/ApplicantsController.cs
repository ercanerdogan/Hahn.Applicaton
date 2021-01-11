using AutoMapper;
using Hahn.ApplicatonProcess.December2020.API.DTOs;
using Hahn.ApplicatonProcess.December2020.API.Filters;
using Hahn.ApplicatonProcess.December2020.Business.Services;
using Hahn.ApplicatonProcess.December2020.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(contentType:"application/json")]  //to give extra informations for usage of API  
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicantsController> _logger;
        public ApplicantsController(IApplicantService applicantService,
            IMapper mapper, ILogger<ApplicantsController> logger)
        {
            _applicantService = applicantService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Returns all applicants 
        /// </summary>
        /// <response code="200">Returns all applicants</response>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applicants = await _applicantService.GetAllAsync();
            return Ok(applicants);
        }

        //to give extra informations for usage of API  
        /// <summary>
        /// Return an applicant by id 
        /// </summary>
        /// <response code="200">Return an applicant by id</response>
        /// <response code="404">Applicant not found</response>
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var applicant = await _applicantService.GetByIdAsync(id);
            return Ok(_mapper.Map<ApplicantDto>(applicant));
        }

        /// <summary>
        /// Create a new applicant
        /// </summary>
        /// <response code="200">Create a new applicant</response>

        [HttpPost]
        [ProducesResponseType(typeof(ApplicantDto), statusCode: 201)] //to give extra informations for usage of API  
        [ProducesResponseType(typeof(ErrorDto), statusCode: 400)]
        public async Task<IActionResult> Create(ApplicantDto applicantDto)
        {
            var newApplicant = await _applicantService.AddAsync(_mapper.Map<Applicant>(applicantDto));
            if (newApplicant != null)
            {
                return Created(string.Empty, _mapper.Map<ApplicantDto>(newApplicant));
            }
            else
            {
                ErrorDto errorDto = new ErrorDto
                {
                    StatusCode = 400
                };
                errorDto.Errors.Add($"Applicant couldn't create");

                _logger.LogError($"HTTP 400 : Applicant couldn't create");

                return BadRequest(errorDto);
            }

        }

        //to give extra informations for usage of API  
        /// <summary>
        /// Update applicant information
        /// </summary>
        /// <response code="200">Update applicant information</response>
        /// <response code="404">Applicant not found</response>

        [HttpPut]
        [ProducesResponseType(typeof(ApplicantDto), statusCode: 201)] //to give extra informations for usage of API  
        [ProducesResponseType(typeof(ErrorDto), statusCode: 400)]
        public IActionResult Update(ApplicantDto applicantDto)
        {
            var applicant = _applicantService.Update(_mapper.Map<Applicant>(applicantDto));

            if (applicant == null)
            {
                ErrorDto errorDto = new ErrorDto
                {
                    StatusCode = 400
                };
                errorDto.Errors.Add($"Applicant couldn't update");

                _logger.LogError($"HTTP 400 : Applicant couldn't update");

                return BadRequest(errorDto);
            }

            return Ok(_mapper.Map<ApplicantDto>(applicant));
        }

        //to give extra informations for usage of API  
        /// <summary>
        /// Delete applicant by id 
        /// </summary>
        /// <response code="204">Delete applicant by id</response>
        /// <response code="404">Applicant not found</response>
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicant = _applicantService.GetByIdAsync(id).Result;
            _applicantService.Delete(applicant);

            return NoContent();

        }

    }
}
