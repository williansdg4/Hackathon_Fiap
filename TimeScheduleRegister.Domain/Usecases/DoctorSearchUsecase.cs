using Shared.Domain.Auxiliar;
using TimeScheduleRegister.Domain.Repositories;

namespace TimeScheduleRegister.Domain.Usecases
{
    public class DoctorSearchUsecase(IDoctorRepository _repository) : IDoctorSearchUsecase
    {
        public int GetDoctorId(int crm)
        {
            var entity = _repository.Get(d => d.Crm == crm) ?? throw new NotFoundException(ErrorMessages.DoctorExists);

            return entity.Id;
        }
    }
}
