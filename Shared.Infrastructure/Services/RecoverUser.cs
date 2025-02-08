using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Services
{
    public class RecoverUser(ApplicationDbContext context) : EFRepository<Patient>(context),
        IRecoverUser
    {
    }
}
