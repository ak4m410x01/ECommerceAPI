using ECommerceAPI.Application.Interfaces.Services.Mail;
using ECommerceAPI.Shared.Helpers.MailConfiguration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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

                // Bypass SSL certificate validation (for development/testing purposes only)
                mailClient.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                // Connect to the SMTP server
                await mailClient.ConnectAsync(_mailConfiguration.Host, _mailConfiguration.Port, SecureSocketOptions.StartTls);

                // Authenticate using the provided credentials
                await mailClient.AuthenticateAsync(_mailConfiguration.UserName, _mailConfiguration.Password);

                // Send the email
                await mailClient.SendAsync(mailMessage);

                // Disconnect from the server
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