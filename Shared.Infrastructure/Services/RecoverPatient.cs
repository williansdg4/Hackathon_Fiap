using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Services
{
    public class RecoverPatient(ApplicationDbContextConsumer context) : ConsumerRepository<Patient>(context),
        IRecoverPatient
    {
    }
}
