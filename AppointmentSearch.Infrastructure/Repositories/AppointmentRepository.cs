using AppointmentSearch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace AppointmentSearch.Infrastructure.Repositories
{
    public class AppointmentRepository(ApplicationDbContext context) : EFRepository<Appointment>(context), IAppointmentRepository
    {
        public override IQueryable<Appointment> DbSetIncluded() =>
            _dbSet.Include(d => d.TimeSchedule).Include(d => d.Patient).Include(d => d.Doctor);

    }
}
