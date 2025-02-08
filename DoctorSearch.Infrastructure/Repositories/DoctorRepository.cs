using DoctorSearch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace DoctorSearch.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : EFRepository<Doctor>(context), IDoctorRepository
    {
        public override IQueryable<Doctor> DbSetIncluded() =>
            _dbSet.Include(d => d.TimeSchedule);
        
    }
}
