using AppointmentSearch.Domain.Mappers;
using AppointmentSearch.Domain.Models;
using AppointmentSearch.Domain.Repositories;
using Shared.Domain.Enums;

namespace AppointmentSearch.Domain.Usecases
{
    public class AppointmentSearchUsecase(IAppointmentRepository _repository) : IAppointmentSearchUsecase
    {
        public IEnumerable<GetAppointmentByPatient> GetByPatient(string cpf)
        {
            var list = _repository
                .Where(a => a.Patient.Cpf == cpf, true)
                .Select(a => a.FromEntity());

            return list;
        }

        public IEnumerable<GetAppointmentByDoctorAndStatus> GetPendingByDoctor(int crm)
        {
            var list = _repository
                .Where(a => a.Status == AppointmentStatusEnum.Pending && a.Doctor.Crm == crm, true)
                .Select(a => a.FromEntityToDoctorAndStatus());

            return list;
        }
    }
}
