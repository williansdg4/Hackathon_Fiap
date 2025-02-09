using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Services
{
    public class RecoverPatientConsumer(ApplicationDbContextConsumer context) : ConsumerRepository<Patient>(context),
        IRecoverPatientConsumer
    {
    }
}
