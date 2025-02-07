using Shared.Domain.Models;
using Shared.Rabbit.Infra;

namespace AppointmentConsumer.Worker.Configurations
{
    public static class StartupExtensions
    {
        public static void AddPatientQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<PatientModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.PatientQueue.ExchangeName);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.PatientQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.PatientQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.PatientQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.PatientQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.PatientQueue.AwaitTime);
            });
        }

        public static void AddDoctorQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<DoctorModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.DoctorQueue.ExchangeNmae);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.DoctorQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.DoctorQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.DoctorQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.DoctorQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.DoctorQueue.AwaitTime);
            });
        }

        public static void AddAppointmentQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<AppointmentModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.AppointmentQueue.ExchangeNmae);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.AppointmentQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.AppointmentQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.AppointmentQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.AppointmentQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.AppointmentQueue.AwaitTime);
            });
        }

        public static void AddTimeScheduleQueue(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumer<TimeScheduleModel>(options =>
            {
                options.ExchangeName = configuration.GetValue<string>(ApplicationVariables.Queues.TimeScheduleQueue.ExchangeNmae);
                options.QueueName = configuration.GetValue<string>(ApplicationVariables.Queues.TimeScheduleQueue.QueueName);
                options.RoutingKey = configuration.GetValue<string>(ApplicationVariables.Queues.TimeScheduleQueue.RoutingKey);
                options.ThreadsCount = configuration.GetValue<int>(ApplicationVariables.Queues.TimeScheduleQueue.ThreadCount);
                options.Retries = configuration.GetValue<int>(ApplicationVariables.Queues.TimeScheduleQueue.Retries);
                options.AwaitQueueTime = configuration.GetValue<int>(ApplicationVariables.Queues.TimeScheduleQueue.AwaitTime);
            });
        }
    }
}
