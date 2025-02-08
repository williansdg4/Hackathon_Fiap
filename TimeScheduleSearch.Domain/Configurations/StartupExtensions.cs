using TimeScheduleSearch.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;

namespace TimeScheduleSearch.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationDomain(this IServiceCollection services)
        {
            services.AddScoped<ITimeScheduleSearchUsecase, TimeScheduleSearchUsecase>();
        }
    }
}
