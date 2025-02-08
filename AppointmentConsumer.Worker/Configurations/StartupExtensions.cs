using Shared.Domain.Models;
using Shared.Rabbit.Infra;

namespace AppointmentConsumer.Worker.Configurations
{
    public static class StartupExtensions
    {
        public static void AddInsertAppointmentQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<InsertAppointmentModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.InsertQueue.ExchangeName);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.InsertQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.InsertQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.InsertQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.InsertQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.InsertQueue.AwaitTime);
            });
        }

        public static void AddUpdateAppointmentQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<UpdateAppointmentModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.UpdateQueue.ExchangeName);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.UpdateQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.UpdateQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.UpdateQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.UpdateQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.UpdateQueue.AwaitTime);
            });
        }
    }
}
