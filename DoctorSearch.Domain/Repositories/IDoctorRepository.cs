using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace DoctorSearch.Domain.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
    }
}
