using TimeScheduleRegister.Domain.Mappers;
using TimeScheduleRegister.Domain.Models;
using TimeScheduleRegister.Domain.Repositories;
using Shared.Domain.Auxiliar;

namespace TimeScheduleRegister.Domain.Usecases
{
    public class TimeScheduleRegisterUsecase(ITimeScheduleRepository _repository) : ITimeScheduleRegisterUsecase
    {
        public void Create(InsertTimeSchedule model)
        {
            if (_repository.Exists(t => t.IdDoctor == model.IdDoctor && t.AvailableDate == model.Date && t.AvailableHours == model.Hour.ToString()))
                throw new AlreadyExistsException("Schedule already exists");

            _repository.Insert(model.ToEntity());
        }

        public void Update(UpdateTimeSchedule model)
        {
            var entity = _repository.Get(model.Id) ?? throw new NotFoundException("Schedule not found");

            if (_repository.Exists(t => t.IdDoctor == entity.IdDoctor && t.AvailableDate == model.Date && t.AvailableHours == model.Hour.ToString()))
                throw new AlreadyExistsException("Schedule already exists");

            entity.AvailableHours = model.Hour;
            entity.AvailableDate = model.Date;

            _repository.Update(entity);
        }
    }
}
