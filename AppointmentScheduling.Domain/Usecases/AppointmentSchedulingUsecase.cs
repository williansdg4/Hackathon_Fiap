using AppointmentScheduling.Domain.Mappers;
using AppointmentScheduling.Domain.Models;
using AppointmentScheduling.Domain.Repositories;

namespace AppointmentScheduling.Domain.Usecases
{
    public class AppointmentSchedulingUsecase(IAppointmentSchedulingRepository _repository) : IAppointmentSchedulingUsecase
    {
        public void AppointmentSchedulingUpdate(RequestNewAppointmentStatusModel model)
        {
            _repository.Update(model.RequestUpdateToEntity());
        }

        public void AppointmentSchedulingInsert(RequestNewAppointmentModel model)
        {
            _repository.Insert(model.RequestInsertToEntity());
        }
    }
}
