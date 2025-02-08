using AppointmentSearch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace AppointmentSearch.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : EFRepository<Patient>(context), IPatientRepository
    {
        //public override IQueryable<Doctor> DbSetIncluded() =>
        //    _dbSet.Include(d => d.TimeSchedule);
        
    }
}
