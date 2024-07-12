namespace ECommerceAPI.Shared.Helpers.MailConfiguration
{
    public class MailData
    {
        #region Properties

        public string MailToName { get; set; }
        public string MailToId { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        #endregion Properties

        #region Constructors

        public MailData(string mailToName, string mailToId, string mailSubject, string mailBody)
        {
            MailToName = mailToName;
            MailToId = mailToId;
            MailSubject = mailSubject;
            MailBody = mailBody;
        }

        #endregion Constructors
    }
}