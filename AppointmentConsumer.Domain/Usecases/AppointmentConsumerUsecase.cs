using AppointmentConsumer.Domain.Repositories;
using Shared.Domain.Models;
using Shared.Domain.Mappers;
using Shared.Infrastructure.Services;
using Shared.Domain.Enums;

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
                    var appointment = _repository.Insert(insertEntity);
                    var user = _repository.Where(a => a.Id == appointment.Id, true)
                    .FirstOrDefault();
                    _emailService.SendEmailAsync("O horario escolhido foi agendado com sucesso!", user.Patient.Email, user.Patient.Name, null);
                }
                else
                {
                    _emailService.SendEmailAsync("O horario escolhido está indisponível!", null, null, insertEntity.IdPatient);
                }
            }
        }

        public void Update(T entity)
        {
            if (entity is UpdateAppointmentModel updateModel)
            {
                _repository.AppointmentUpdate(updateModel.ToEntity());

                var user = _repository.Where(a => a.Id == updateModel.Id, true)
                    .FirstOrDefault();

                if (updateModel.Status == AppointmentStatusEnum.Cancelled)
                {
                    _emailService.SendEmailAsync($"Atendimento cancellado: {updateModel.CancellationJustification}!", user.Doctor.Email, user.Doctor.Name, null);
                }
                else
                {
                    _emailService.SendEmailAsync("Status do agendamento atualizado com sucesso!", null, null, user.IdPatient);
                }
            }
        }
    }
}
