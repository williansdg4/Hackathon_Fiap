using AppointmentScheduling.Domain.Models;

namespace AppointmentScheduling.Domain.Usecases
{
    public interface IAppointmentSchedulingUsecase
    {
        void AppointmentSchedulingUpdate(RequestNewAppointmentStatusModel model);
        void AppointmentSchedulingInsert(RequestNewAppointmentModel model, string user, string email);
    }
}
