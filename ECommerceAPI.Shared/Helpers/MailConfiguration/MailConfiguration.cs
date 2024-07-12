namespace ECommerceAPI.Shared.Helpers.MailConfiguration
{
    public class MailConfiguration
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool DefaultCredentials { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool UseSSL { get; set; }
    }
}