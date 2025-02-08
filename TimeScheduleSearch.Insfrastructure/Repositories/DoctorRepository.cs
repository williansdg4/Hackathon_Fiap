using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;
using TimeScheduleSearch.Domain.Repositories;

namespace TimeScheduleSearch.Infrastructure.Repositories
{
    public class TimeScheduleRepository(ApplicationDbContext context) : EFRepository<TimeSchedule>(context), ITimeScheduleRepository
    {
        public override IQueryable<TimeSchedule> DbSetIncluded() =>
            _dbSet.Include(d => d.Doctor);
    }
}
