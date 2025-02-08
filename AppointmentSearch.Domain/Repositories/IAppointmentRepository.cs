using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace AppointmentSearch.Domain.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
    }
}
