using AppointmentConsumer.Domain.Repositories;
using Shared.Domain.Models;
using Shared.Domain.Mappers;
using Shared.Infrastructure.Services;

namespace AppointmentConsumer.Domain.Usecases
{
    public class AppointmentConsumerUsecase<T>(IAppointmentConsumerRepository _repository, IEmailService _emailService)
        : IAppointmentConsumerUsecase<T> where T : AppointmentModel
    {
        public void Insert(T entity)
        {
            if (entity is InsertAppointmentModel insertModel)
            {
                var insertEntity = insertModel.ToEntity();

                var check = _repository.AppointmentCheck(insertEntity);

                if (check)
                {
                    _repository.Insert(insertEntity);
                    _emailService.SendEmailAsync("O horario escolhido foi agendado com sucesso!", insertEntity.IdPatient);
                }
                else
                {
                    _emailService.SendEmailAsync("O horario escolhido está indisponível!", insertEntity.IdPatient);
                }
            }
        }

        public void Update(T entity)
        {
            if (entity is UpdateAppointmentModel updateModel)
            {
                _repository.AppointmentUpdate(updateModel.ToEntity());
                _emailService.SendEmailAsync("Status do agendamento atualizado com sucesso!", updateModel.IdPatient);
            }
        }
    }
}
