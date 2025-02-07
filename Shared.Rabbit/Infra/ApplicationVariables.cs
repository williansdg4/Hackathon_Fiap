namespace Shared.Rabbit.Infra
{
    public static class ApplicationVariables
    {
        public static class Rabbit
        {
            public const string Host = "RabbitHostName";
            public const string Port = "RabbitPort";
            public const string User = "RabbitUsername";
            public const string Password = "RabbitPassword";
            public const string VirtualHost = "RabbitVirtualHost";
        }

        public static class Queues
        {
            public static class PatientQueue
            {
                public const string ExchangeName = "HealthMedSchedulingExchange";
                public const string QueueName = "PatientQueueName";
                public const string RoutingKey = "PatientRoutingKey";
                public const string ThreadCount = "PatientThreadCount";
                public const string Retries = "PatientRetries";
                public const string AwaitTime = "PatientAwaitTime";
            }
            public static class DoctorQueue
            {
                public const string ExchangeNmae = "HealthMedSchedulingExchange";
                public const string QueueName = "DoctorQueueName";
                public const string RoutingKey = "DoctorRoutingKey";
                public const string ThreadCount = "DoctorThreadCount";
                public const string Retries = "DoctorRetries";
                public const string AwaitTime = "DoctorAwaitTime";
            }
            public static class AppointmentQueue
            {
                public const string ExchangeNmae = "HealthMedSchedulingExchange";
                public const string QueueName = "AppointmentQueueName";
                public const string RoutingKey = "AppointmentRoutingKey";
                public const string ThreadCount = "AppointmentThreadCount";
                public const string Retries = "AppointmentRetries";
                public const string AwaitTime = "AppointmentAwaitTime";
            }
            public static class TimeScheduleQueue
            {
                public const string ExchangeNmae = "HealthMedSchedulingExchange";
                public const string QueueName = "TimeScheduleQueueName";
                public const string RoutingKey = "TimeScheduleRoutingKey";
                public const string ThreadCount = "TimeScheduleThreadCount";
                public const string Retries = "TimeScheduleRetries";
                public const string AwaitTime = "TimeScheduleAwaitTime";
            }
        }
    }
}
