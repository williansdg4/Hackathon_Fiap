using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace Account.Domain.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
    }
}
