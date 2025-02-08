using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace AppointmentConsumer.Domain.Repositories
{
    public interface IAppointmentConsumerRepository : IRepository<Appointment>
    {
        void AppointmentUpdate(Appointment entity);
        bool AppointmentCheck(Appointment entity);
    }
}
