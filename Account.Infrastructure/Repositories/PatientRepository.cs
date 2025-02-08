using Account.Domain.Repositories;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace Account.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : EFRepository<Patient>(context), IPatientRepository
    {
    }
}
