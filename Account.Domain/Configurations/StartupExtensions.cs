using Account.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationDomain(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRegistrationUsecase, DoctorRegistrationUsecase>();
            services.AddScoped<IPatientRegistrationUsecase, PatientRegistrationUsecase>();
        }
    }
}
