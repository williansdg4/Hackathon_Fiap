using DoctorSearch.Domain.Repositories;
using DoctorSearch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorSearch.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
        }

        public static void ConfigurationServices(this IServiceCollection services)
        {

        }
    }
}
