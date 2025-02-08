using TimeScheduleRegister.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;

namespace TimeScheduleRegister.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationDomain(this IServiceCollection services)
        {
            services.AddScoped<ITimeScheduleRegisterUsecase, TimeScheduleRegisterUsecase>();
            services.AddScoped<IDoctorSearchUsecase, DoctorSearchUsecase>();
        }
    }
}
