using ECommerceAPI.Application.Interfaces.Services.Mail;
using ECommerceAPI.Shared.Helpers.MailConfiguration;
using System.Net;
using System.Net.Mail;

namespace ECommerceAPI.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        #region Properties

        private readonly MailConfiguration _mailConfiguration;

        #endregion Properties

        #region Constructors

        public MailService(MailConfiguration mailConfiguration)
        {
            _mailConfiguration = mailConfiguration;
        }

        #endregion Constructors

        public Task SendAsync(string toEmail, string subject, string body, bool isBodyHTML)
        {
            var client = new SmtpClient(_mailConfiguration.MailServer, _mailConfiguration.MailPort)
            {
                Credentials = new NetworkCredential(_mailConfiguration.FromMail, _mailConfiguration.Password),
                EnableSsl = true
            };

            var message = new MailMessage(_mailConfiguration.FromMail!, toEmail, subject, body)
            {
                IsBodyHtml = isBodyHTML
            };

            return client.SendMailAsync(message);
        }
    }
}