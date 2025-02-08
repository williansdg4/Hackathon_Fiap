namespace Shared.Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string errorMessage, int id, bool isPatient);
    }
}
