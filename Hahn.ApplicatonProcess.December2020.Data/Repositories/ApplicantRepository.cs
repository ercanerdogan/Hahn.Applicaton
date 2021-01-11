using Hahn.ApplicatonProcess.December2020.Core.Models;
using Hahn.ApplicatonProcess.December2020.Core.Repositories;

namespace Hahn.ApplicatonProcess.December2020.Data.Repositories
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ApplicantRepository(AppDbContext context) : base(context) 
        {

        }
    }
}
