using Account.Domain.Models;
using Shared.Domain.Entities;

namespace Account.Domain.Mappers
{
    public static class DomainMapper
    {
        public static Doctor ToEntity(this InsertDoctorModel model) => new()
        {
            Crm = model.Crm,
            Name = model.Name,
            Specialty = model.Specialty,
            Password = string.Empty,
        };

        public static Patient ToEntity(this InsertPatientModel model) => new()
        {
            Cpf = model.Cpf,
            Name = model.Name,
            Email = model.Email,
            Password = string.Empty,
        };
    }
}
