
using AppointmentSearch.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSearch.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationDomain(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentSearchUsecase, AppointmentSearchUsecase>();
        }
    }
}
