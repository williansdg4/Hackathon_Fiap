using Shared.Domain.Models;

namespace AppointmentConsumer.Domain.Usecases
{
    public interface IAppointmentConsumerUsecase<T> where T : AppointmentModel
    {
        void Insert(T entity);
        void Update(T entity);
    }
}
