using AppointmentConsumer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Domain.Enums;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace AppointmentConsumer.Infrastructure.Repositories
{
    public class AppointmentConsumerRepository(ApplicationDbContextConsumer context) : ConsumerRepository<Appointment>(context),
        IAppointmentConsumerRepository
    {
        public void AppointmentUpdate(Appointment entity)
        {
            context.Appointments
                .Where(a => a.Id == entity.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(a => a.Status, entity.Status)
                    .SetProperty(a => a.CancellationJustification, entity.CancellationJustification));
            context.SaveChanges();
        }

        public bool AppointmentCheck(Appointment entity)
        {
            var appointment = context.Appointments
                .Where(a => a.IdDoctor == entity.IdDoctor && 
                       a.IdTimeSchedule == entity.IdTimeSchedule && 
                       a.Status != AppointmentStatusEnum.Cancelled)
                .FirstOrDefault();

            return appointment is null;
        }
    }
}
