using Account.Domain.Mappers;
using Account.Domain.Models;
using Account.Domain.Repositories;
using Shared.Domain.Auxiliar;

namespace Account.Domain.Usecases
{
    public class DoctorRegistrationUsecase(IDoctorRepository _repository) : IDoctorRegistrationUsecase
    {
        public void Create(InsertDoctorModel model)
        {
            if (_repository.Exists(r => r.Crm == model.Crm))
                throw new AlreadyExistsException(ErrorMessages.DoctorExists);

            _repository.Insert(model.ToEntity());
        }
    }
}
