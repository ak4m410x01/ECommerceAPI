using ECommerceAPI.Application.Interfaces.Services.Media;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure.Services.Media
{
    public class MediaService : IMediaService
    {
        #region Properties

        private readonly IWebHostEnvironment _host;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Properties

        #region Constructors

        public MediaService(IWebHostEnvironment host, IHttpContextAccessor httpContextAccessor)
        {
            _host = host;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructors

        #region Methods

        public async Task<string> SaveAsync(IFormFile media, params string[] paths)
        {
            var mediaName = ConstructMediaName(media.FileName);

            var directory = ConstructDirectoryPath(paths);

            var mediaPath = Path.Combine(directory, mediaName);

            await SaveMediaAsync(media, mediaPath);

            return ConstructMediaUrl(mediaPath);

            #endregion Methods
        }

        public Task DeleteAsync(string url)
        {
            var file = ConvertUrlToMediaPath(url);

            if (File.Exists(file))
                File.Delete(file);

            return Task.CompletedTask;
        }

        public async Task<string?> UpdateAsync(string? url, IFormFile? media, params string[] paths)
        {
            if (!string.IsNullOrEmpty(url))
                await DeleteAsync(url);

            return media == null ? null : await SaveAsync(media, paths);
        }

        private string ConstructMediaName(string mediaName)
        {
            return $"{Path.GetFileNameWithoutExtension(mediaName)}-{Guid.NewGuid()}{Path.GetExtension(mediaName).ToLower()}";
        }

        private string ConstructDirectoryPath(string[] paths)
        {
            var directory = $"{Path.Combine(_host.WebRootPath, "Media", Path.Combine(paths))}";
            Directory.CreateDirectory(directory);
            return directory;
        }

        private async Task SaveMediaAsync(IFormFile media, string filePath)
        {
            await using var stream = new FileStream(filePath, FileMode.Create);
            await media.CopyToAsync(stream);
        }

        private string ConstructMediaUrl(string mediaPath)
        {
            var relativePath = Path.GetRelativePath(_host.WebRootPath, mediaPath).Replace(Path.DirectorySeparatorChar.ToString(), "/");

            var request = _httpContextAccessor.HttpContext!.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            return $"{baseUrl}/{relativePath}";
        }

        private string ConvertUrlToMediaPath(string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            var relativePath = uri.IsAbsoluteUri ? uri.AbsolutePath.TrimStart('/') : url.TrimStart('/');

            return Path.Combine(_host.WebRootPath, relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
        }
    }
}