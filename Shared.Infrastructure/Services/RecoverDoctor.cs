using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Services
{
    public class RecoverDoctor(ApplicationDbContextConsumer context) : ConsumerRepository<Doctor>(context),
        IRecoverDoctor
    {
    }
}
