using Account.Domain.Mappers;
using Account.Domain.Models;
using Account.Domain.Repositories;
using Shared.Domain.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domain.Usecases
{
    public class PatientRegistrationUsecase(IPatientRepository _repository) : IPatientRegistrationUsecase
    {
        public void Create(InsertPatientModel model)
        {
            if (_repository.Exists(r => r.Cpf == model.Cpf))
                throw new AlreadyExistsException(ErrorMessages.PatientExists);

            _repository.Insert(model.ToEntity());
        }
    }
}
