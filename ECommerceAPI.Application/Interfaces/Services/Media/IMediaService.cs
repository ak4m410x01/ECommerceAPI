using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Interfaces.Services.Media
{
    public interface IMediaService
    {
        Task<string> SaveAsync(IFormFile media, params string[] paths);

        Task DeleteAsync(string url);

        Task<string?> UpdateAsync(string? url, IFormFile? media, params string[] paths);
    }
}