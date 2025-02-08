using AppointmentConsumer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace AppointmentConsumer.Infrastructure.Repositories
{
    public class AppointmentConsumerRepository(ApplicationDbContext context) : EFRepository<Appointment>(context),
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
    }
}
