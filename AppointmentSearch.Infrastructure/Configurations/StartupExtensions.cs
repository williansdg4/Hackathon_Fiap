using AppointmentSearch.Domain.Repositories;
using AppointmentSearch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSearch.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }

        public static void ConfigurationServices(this IServiceCollection services)
        {

        }
    }
}
