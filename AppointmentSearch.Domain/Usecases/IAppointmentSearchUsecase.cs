using AppointmentSearch.Domain.Models;

namespace AppointmentSearch.Domain.Usecases
{
    public interface IAppointmentSearchUsecase
    {
        IEnumerable<GetAppointmentByPatient> GetByPatient(string cpf);
        IEnumerable<GetAppointmentByDoctorAndStatus> GetPendingByDoctor(int crm);
    }
}
