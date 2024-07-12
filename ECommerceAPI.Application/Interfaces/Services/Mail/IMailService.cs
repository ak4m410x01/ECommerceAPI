using ECommerceAPI.Shared.Helpers.MailConfiguration;

namespace ECommerceAPI.Application.Interfaces.Services.Mail
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData);
    }
}