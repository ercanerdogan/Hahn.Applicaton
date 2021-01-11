using Hahn.ApplicatonProcess.December2020.Core.Repositories;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IApplicantRepository Applicants { get; }

        Task CommitAsync();
        void Commit();
    }
}
