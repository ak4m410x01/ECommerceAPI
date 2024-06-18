namespace ECommerceAPI.Domain.Constants.Media
{
    public static class Image
    {
        public static string[] AllowedExtensions { get; } = [".jpg", ".jpeg", ".png"];
        public static string[] AllowedMimeTypes { get; } = ["image/jpeg", "image/png"];
    }
}