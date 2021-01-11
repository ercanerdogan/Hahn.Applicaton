using Hahn.ApplicatonProcess.December2020.Core.Repositories;
using Hahn.ApplicatonProcess.December2020.Core.UnitOfWorks;
using Hahn.ApplicatonProcess.December2020.Data.Repositories;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ApplicantRepository _applicantRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IApplicantRepository Applicants => _applicantRepository = _applicantRepository ?? new ApplicantRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
