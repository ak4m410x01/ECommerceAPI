namespace ECommerceAPI.Shared.Helpers.MailConfiguration
{
    public class MailConfiguration
    {
        public string? MailServer { get; set; }
        public int MailPort { get; set; }
        public string? SenderName { get; set; }
        public string? FromMail { get; set; }
        public string? Password { get; set; }
    }
}