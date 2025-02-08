using Shared.Domain.Entities;

namespace AppointmentScheduling.Domain.Repositories
{
    public interface IAppointmentSchedulingRepository
    {
        void Insert(Appointment entity);
        void Update(Appointment entity);
    }
}
