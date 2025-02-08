using TimeScheduleRegister.Domain.Repositories;
using TimeScheduleRegister.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace TimeScheduleRegister.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<ITimeScheduleRepository, TimeScheduleRepository>();
        }

        public static void ConfigurationServices(this IServiceCollection services)
        {

        }
    }
}
