using Account.Domain.Repositories;
using Account.Infrastructure.Implementations;
using Account.Infrastructure.Interfaces;
using Account.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Authentication;

namespace Account.Infrastructure
{
    public static class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
