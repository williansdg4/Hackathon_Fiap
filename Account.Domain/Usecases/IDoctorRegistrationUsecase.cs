using Account.Domain.Models;

namespace Account.Domain.Usecases
{
    public interface IDoctorRegistrationUsecase
    {
        void Create(InsertDoctorModel model);
    }
}
