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
        private readonly IRecoverPatient _recoverEmailUser;

        public EmailService(IRecoverPatient recoverEmailUser)
        {
            _recoverEmailUser = recoverEmailUser;

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

        public async Task SendEmailAsync(string message, int id, bool isPatient)
        {
            
            if (isPatient)
            {
                var patient = _recoverEmailUser.Get(id);

                if (patient != null)
                {
                    try
                    {
                        var email = new MimeMessage();
                        email.From.Add(new MailboxAddress("Sistema", _emailSender));
                        email.To.Add(new MailboxAddress("Admin", patient.Email));
                        email.Subject = "Agendamento de consulta";
                        email.Body = new TextPart("plain") { Text = $"Olá {patient.Name}.\n\n{message}" };

                        using var smtp = new SmtpClient();
                        await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                        await smtp.AuthenticateAsync(_emailSender, _emailPassword);
                        await smtp.SendAsync(email);
                        await smtp.DisconnectAsync(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
            else
            {
                var doctor = _recoverEmailUser.Get(id);

                if (doctor != null)
                {
                    try
                    {
                        var email = new MimeMessage();
                        email.From.Add(new MailboxAddress("Sistema", _emailSender));
                        email.To.Add(new MailboxAddress("Admin", doctor.Email));
                        email.Subject = "Agendamento de consulta";
                        email.Body = new TextPart("plain") { Text = $"Olá {doctor.Name}.\n\n{message}" };

                        using var smtp = new SmtpClient();
                        await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                        await smtp.AuthenticateAsync(_emailSender, _emailPassword);
                        await smtp.SendAsync(email);
                        await smtp.DisconnectAsync(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
        }
    }
}
