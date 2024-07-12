using ECommerceAPI.Application.Interfaces.Services.Mail;
using ECommerceAPI.Shared.Helpers.MailConfiguration;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;

namespace ECommerceAPI.Infrastructure.Services.Mail
{
    public class MailService : IMailService
    {
        #region Properties

        private readonly MailConfiguration _mailConfiguration;
        private readonly ILogger<MailService> _logger;

        #endregion Properties

        #region Constructors

        public MailService(MailConfiguration mailConfiguration, ILogger<MailService> logger)
        {
            _mailConfiguration = mailConfiguration;
            _logger = logger;
        }

        #endregion Constructors

        public async Task<bool> SendAsync(MailData mailData)
        {
            try
            {
                var mailMessage = new MimeMessage();

                // Mail From
                var mailFrom = new MailboxAddress(_mailConfiguration.Name, _mailConfiguration.EmailId);
                mailMessage.From.Add(mailFrom);

                // Mail To
                var mailTo = new MailboxAddress(mailData.MailToName, mailData.MailToId);
                mailMessage.To.Add(mailTo);

                // Mail Subject
                mailMessage.Subject = mailData.MailSubject;

                // Mail Body
                var mailBody = new BodyBuilder();
                mailBody.TextBody = mailData.MailBody;
                mailMessage.Body = mailBody.ToMessageBody();

                // Mail Client
                using var mailClient = new SmtpClient();

                await mailClient.ConnectAsync(_mailConfiguration.Host, _mailConfiguration.Port, _mailConfiguration.UseSSL);
                await mailClient.AuthenticateAsync(_mailConfiguration.EmailId, _mailConfiguration.Password);
                await mailClient.SendAsync(mailMessage);
                await mailClient.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending email.");

                return false;
            }
        }
    }
}