using ECommerceAPI.Application.Interfaces.Services.Media;
using ECommerceAPI.Infrastructure.Services.Media;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Infrastructure.Extensions.Media
{
    public static class MediaServiceCollection
    {
        public static IServiceCollection AddMediaService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IMediaService), typeof(MediaService));
            return services;
        }
    }
}