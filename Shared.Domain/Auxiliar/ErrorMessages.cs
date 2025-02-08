using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Auxiliar
{
    public class ErrorMessages
    {
        public const string CrmRequired = "CRM é obrigatório";
        public const string InvalidCrm = "CRM inválido";

        public const string NameRequired = "Nome é obrigatório";
        public const string SpecialtyRequired = "Especialidade é obrigatória";        
        
        public const string CpfRequired = "CPF é obrigatório";
        public const string InvalidCpf = "CPF inválido";

        public const string UserRequired = "Usuário é obrigatório";
        public const string PasswordRequired = "Senha é obrigatória";
        
        public const string EmailRequired = "E-mail é obrigatório";
        public const string InvalidEmail = "E-mail inválido";

        public const string JustificationLength = "A justificativa de cancelamento não pode ter mais de 30 caracteres.";

        public const string HourRequired = "Hora é obrigatória";
        public const string InvalidDate = "Data inválida";
        public const string InvalidHour = "Hora inválida";




    }
}
