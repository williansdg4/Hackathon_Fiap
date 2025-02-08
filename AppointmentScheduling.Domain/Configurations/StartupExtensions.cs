using AppointmentScheduling.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentScheduling.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentSchedulingUsecase, AppointmentSchedulingUsecase>();
        }
    }
}
