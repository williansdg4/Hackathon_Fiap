using Account.Domain.Models;

namespace Account.Domain.Usecases
{
    public interface IPatientRegistrationUsecase
    {
        void Create(InsertPatientModel model);
    }
}
