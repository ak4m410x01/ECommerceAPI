using ECommerceAPI.Application.Interfaces.Services.Mail;
using ECommerceAPI.Infrastructure.Services.Mail;
using ECommerceAPI.Shared.Helpers.MailConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions.Mail
{
    public static class MailServiceCollection
    {
        public static IServiceCollection AddMailService(this IServiceCollection services, IConfiguration configuration)
        {
            var mailConfiguration = configuration.GetSection("MailConfiguration").Get<MailConfiguration>();
            services.AddSingleton(mailConfiguration!);

            services.AddScoped(typeof(IMailService), typeof(MailService));
            return services;
        }
    }
}