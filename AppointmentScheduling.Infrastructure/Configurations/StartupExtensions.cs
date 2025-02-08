using AppointmentScheduling.Domain.Repositories;
using AppointmentScheduling.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentScheduling.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentSchedulingRepository, AppointmentSchedulingRepository>();

        }
    }
}
