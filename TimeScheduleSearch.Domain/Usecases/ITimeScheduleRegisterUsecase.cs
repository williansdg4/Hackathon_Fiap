using TimeScheduleSearch.Domain.Models;

namespace TimeScheduleSearch.Domain.Usecases
{
    public interface ITimeScheduleSearchUsecase
    {
        IEnumerable<GetTimeSchedule> Get(int crm);
    }
}
