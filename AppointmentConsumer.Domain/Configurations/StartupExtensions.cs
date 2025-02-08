using AppointmentConsumer.Domain.Usecases;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Models;

namespace AppointmentConsumer.Domain.Configurations
{
    public static class StartupExtensions
    {
        public static void AddDomain<T>(this IServiceCollection services)
            where T : AppointmentModel
        {
            services.AddScoped<IAppointmentConsumerUsecase<T>, AppointmentConsumerUsecase<T>>();
        }
    }
}
