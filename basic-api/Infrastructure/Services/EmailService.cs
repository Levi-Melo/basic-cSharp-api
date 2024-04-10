using basic_api.Data.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace basic_api.Infrastructure.Services
{
    public class EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword) : IEmailService
    {
        private readonly string _smtpServer = smtpServer;
        private readonly int _smtpPort = smtpPort;
        private readonly string _smtpUsername = smtpUsername;
        private readonly string _smtpPassword = smtpPassword;

        public async Task Send(string to, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Seu Nome", _smtpUsername));
                message.To.Add(new MailboxAddress("Destinatário", to));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                using var client = new SmtpClient();
                await client.ConnectAsync(_smtpServer, _smtpPort, true);
                await client.AuthenticateAsync(_smtpUsername, _smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar email: " + ex.Message);
            }
        }
    }
}