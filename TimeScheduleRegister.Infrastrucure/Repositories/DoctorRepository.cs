﻿using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using Shared.Infrastructure.Repositories;
using TimeScheduleRegister.Domain.Repositories;

namespace TimeScheduleRegister.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : EFRepository<Doctor>(context), IDoctorRepository
    {        
    }
}
