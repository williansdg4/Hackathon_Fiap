using TimeScheduleSearch.Domain.Repositories;
using TimeScheduleSearch.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace TimeScheduleSearch.Infrastructure.Configurations
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
