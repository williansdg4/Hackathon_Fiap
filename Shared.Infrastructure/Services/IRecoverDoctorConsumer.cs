using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace Shared.Infrastructure.Services
{
    public interface IRecoverDoctorConsumer : IRepository<Doctor>
    {
    }
}
