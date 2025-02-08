using Account.Domain.Usecases;
using DoctorSearch.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorSearch.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void ConfigurationDomain(this IServiceCollection services)
        {
            services.AddScoped<IDoctorSearchUsecase, DoctorSearchUsecase>();
        }
    }
}
