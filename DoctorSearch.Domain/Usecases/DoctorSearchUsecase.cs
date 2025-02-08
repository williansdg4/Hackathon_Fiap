using DoctorSearch.Domain.Mappers;
using DoctorSearch.Domain.Models;
using DoctorSearch.Domain.Repositories;

namespace DoctorSearch.Domain.Usecases
{
    public class DoctorSearchUsecase(IDoctorRepository _repository) : IDoctorSearchUsecase
    {
        public IEnumerable<GetDoctorsBySpecialty> Get(string specialty)
        {
            var list = _repository
                .Where(r => r.Specialty.Equals(specialty, StringComparison.InvariantCultureIgnoreCase), true)
                .Select(c => c.FromEntity());

            return list;
        }
    }
}
