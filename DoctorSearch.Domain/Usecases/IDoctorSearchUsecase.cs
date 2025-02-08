using DoctorSearch.Domain.Models;

namespace DoctorSearch.Domain.Usecases
{
    public interface IDoctorSearchUsecase
    {
        IEnumerable<GetDoctorsBySpecialty> Get(string specialty);
    }
}
