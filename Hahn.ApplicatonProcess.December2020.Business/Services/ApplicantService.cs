using Hahn.ApplicatonProcess.December2020.Core.Models;
using Hahn.ApplicatonProcess.December2020.Core.Repositories;
using Hahn.ApplicatonProcess.December2020.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Business.Services
{
    public class ApplicantService : Service<Applicant>, IApplicantService
    {
        public ApplicantService(IUnitOfWork unitOfWork, IGenericRepository<Applicant> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
