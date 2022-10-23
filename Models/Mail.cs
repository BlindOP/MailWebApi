namespace MailWebApi.Models
{
    /// <summary>
    /// Contain Email info and result of sending
    /// </summary>
    public class Mail
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public virtual List<RecipientСlass> Recipients { get; set; } = new();
        public DateTime Date { get; set; }
        public string Result { get; set; } = string.Empty;
        public string FailedMessage { get; set; } = string.Empty;

    }
    /// <summary>
    ///Message recipients class
    /// </summary>
    public class RecipientСlass
    {
        public int Id { get; set; }
        public string Recipient { get; set; } = string.Empty;
        public int? MailId { get; set; }
        public Mail? Mail { get; set; }

        public override string ToString()
        {
            return Recipient;
        }

    }
}