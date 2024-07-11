namespace ECommerceAPI.Application.Interfaces.Services.Mail
{
    public interface IMailService
    {
        Task SendAsync(string toEmail, string subject, string body, bool isBodyHTML);
    }
}