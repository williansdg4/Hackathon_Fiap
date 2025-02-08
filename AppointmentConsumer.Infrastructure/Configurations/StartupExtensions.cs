using AppointmentConsumer.Domain.Repositories;
using AppointmentConsumer.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentConsumer.Infrastructure.Configurations
{
    public static class StartupExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentConsumerRepository, AppointmentConsumerRepository>();
        }
    }
}
