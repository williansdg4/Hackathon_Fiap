using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Shared.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _emailSender;
        private readonly string _emailPassword;
        private readonly IRecoverPatientConsumer _recoverEmailPatient;
        private readonly IRecoverDoctorConsumer _recoverEmailDoctor;

        public EmailService(IRecoverPatientConsumer recoverEmailPatient, IRecoverDoctorConsumer recoverEmailDoctor)
        {
            _recoverEmailPatient = recoverEmailPatient;
            _recoverEmailDoctor = recoverEmailDoctor;

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _emailSender = configuration.GetConnectionString("EmailSender")
                ?? throw new Exception("String de conexão não informada");
            _emailPassword = configuration.GetConnectionString("EmailPassword")
                ?? throw new Exception("String de conexão não informada");
            _smtpPort = !string.IsNullOrEmpty(configuration.GetConnectionString("SmtpPort"))
                ? Convert.ToInt32(configuration.GetConnectionString("SmtpPort"))
                : throw new Exception("String de conexão não informada");
            _smtpServer = configuration.GetConnectionString("SmtpServer")
                ?? throw new Exception("String de conexão não informada");
        }

        public void SendEmailAsync(string message, string userEmail, string userName, int? id)
        {
            string emailPatient = null;
            string namePatient = null;
            
            if(id != null)
            {
                var user = _recoverEmailPatient.Get(Convert.ToInt32(id));
                emailPatient = user.Email;
                namePatient = user.Name;
            }
                    
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Sistema", _emailSender));
            email.To.Add(new MailboxAddress("Admin", string.IsNullOrEmpty(userEmail) ? emailPatient : userEmail));
            email.Subject = "Agendamento de consulta";
            email.Body = new TextPart("plain") { Text = $"Olá {(string.IsNullOrEmpty(userName) ? namePatient : userName)}.\n\n{message}" };

            using var smtp = new SmtpClient();
            smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls).Wait();
            smtp.AuthenticateAsync(_emailSender, _emailPassword).Wait();
            smtp.SendAsync(email).Wait();
            smtp.DisconnectAsync(true).Wait();
        }
    }
}
