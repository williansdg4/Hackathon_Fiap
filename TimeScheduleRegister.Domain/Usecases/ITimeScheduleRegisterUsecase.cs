using TimeScheduleRegister.Domain.Models;

namespace TimeScheduleRegister.Domain.Usecases
{
    public interface ITimeScheduleRegisterUsecase
    {
        void Create(InsertTimeSchedule model);
        void Update(UpdateTimeSchedule model);
    }
}
