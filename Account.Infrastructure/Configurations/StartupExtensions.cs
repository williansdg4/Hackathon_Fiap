using Account.Domain.Repositories;
using Account.Infrastructure.Implementations;
using Account.Infrastructure.Interfaces;
using Account.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Authentication;

namespace Account.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
        }

        public static void ConfigurationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IAccountManager, AccountManager>();
        }
    }
}
