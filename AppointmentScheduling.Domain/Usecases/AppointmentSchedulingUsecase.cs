using AppointmentScheduling.Domain.Mappers;
using AppointmentScheduling.Domain.Models;
using AppointmentScheduling.Domain.Repositories;
using Shared.Domain.Entities;
using Shared.Infrastructure.Repositories;

namespace AppointmentScheduling.Domain.Usecases
{
    public class AppointmentSchedulingUsecase(IAppointmentSchedulingRepository _repository, IRepository<Patient> _recoverUser) : IAppointmentSchedulingUsecase
    {
        public void AppointmentSchedulingUpdate(RequestNewAppointmentStatusModel model)
        {
            _repository.Update(model.RequestUpdateToEntity());
        }

        public void AppointmentSchedulingInsert(RequestNewAppointmentModel model, string user, string email)
        {
            var patient = _recoverUser.Get(u => u.Name == user);
            model.IdPatient = patient.Id;

            _repository.Insert(model.RequestInsertToEntity());
        }
    }
}
