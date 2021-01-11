using AutoMapper;
using Hahn.ApplicatonProcess.December2020.API.DTOs;
using Hahn.ApplicatonProcess.December2020.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Applicant, ApplicantDto>();
            CreateMap<ApplicantDto, Applicant>();
        }
    }
}
