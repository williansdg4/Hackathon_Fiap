using TimeScheduleSearch.Domain.Mappers;
using TimeScheduleSearch.Domain.Models;
using TimeScheduleSearch.Domain.Repositories;
using Shared.Domain.Auxiliar;

namespace TimeScheduleSearch.Domain.Usecases
{
    public class TimeScheduleSearchUsecase(ITimeScheduleRepository _repository) : ITimeScheduleSearchUsecase
    {
        public IEnumerable<GetTimeSchedule> Get(int crm)
        {
            var list = _repository
                .Where(a => a.Doctor.Crm == crm, true)
                .Select(a => a.FromEntity());

            return list;
        }
    }
}
