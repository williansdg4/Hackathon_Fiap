using AppointmentConsumer.Domain.Repositories;
using Shared.Domain.Models;
using Shared.Domain.Mappers;

namespace AppointmentConsumer.Domain.Usecases
{
    public class AppointmentConsumerUsecase<T>(IAppointmentConsumerRepository _repository)
        : IAppointmentConsumerUsecase<T> where T : AppointmentModel
    {
        public void Insert(T entity)
        {
            if (entity is InsertAppointmentModel insertModel)
            {
                _repository.Insert(insertModel.ToEntity());
            }
        }

        public void Update(T entity)
        {
            if (entity is UpdateAppointmentModel updateModel)
            {
                _repository.AppointmentUpdate(updateModel.ToEntity());
            }
        }
    }
}
