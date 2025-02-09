namespace Shared.Infrastructure.Services
{
    public interface IEmailService
    {
        void SendEmailAsync(string errorMessage, string userEmail, string userName, int? id);
    }
}
