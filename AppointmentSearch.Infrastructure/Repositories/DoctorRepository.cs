using AppointmentSearch.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;

namespace AppointmentSearch.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : EFRepository<Doctor>(context), IDoctorRepository
    {
    }
}
