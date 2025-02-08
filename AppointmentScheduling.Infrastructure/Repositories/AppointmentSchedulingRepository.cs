using System.Dynamic;
using AppointmentScheduling.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Shared.Domain.Entities;
using Shared.Domain.Enums;
using Shared.Rabbit.Producer;

namespace AppointmentScheduling.Infrastructure.Repositories
{
    public class AppointmentSchedulingRepository(IRabbitProducer _producer, IConfiguration _configuration) : IAppointmentSchedulingRepository
    {
        public void Insert(Appointment entity)
        {
            var message = new
            {
                entity.IdDoctor,
                entity.IdPatient,
                entity.IdTimeSchedule,
                Status = AppointmentStatusEnum.Pending,
            };

            _producer.Publish(message, _configuration.GetSection("InsertedQueueName").Value!);
        }

        public void Update(Appointment entity)
        {
            dynamic message = new ExpandoObject();
            message.Id = entity.Id;
            message.Status = entity.Status;

            if (entity.Status == AppointmentStatusEnum.Cancelled)
            {
                message.CancellationJustification = entity.CancellationJustification;
            }

            _producer.Publish(message, _configuration.GetSection("UpdatedQueueName").Value!);
        }
    }
}
