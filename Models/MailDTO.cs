using System.ComponentModel.DataAnnotations;

namespace MailWebApi.Models
{
    /// <summary>
    /// POST request data object
    /// </summary>
    public class MailRequestDTO
    {
        [Required]
        public string Subject { get; set; } = String.Empty;
        [Required]
        public string Body { get; set; } = String.Empty;
        public List<string> Recipients { get; set; } = new List<string>();

    }
    /// <summary>
    /// Response data object
    /// </summary>
    public class MailDTO
    {
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public List<string> Recipients { get; set; } = new List<string>();
        public DateTime Date { get; set; } 
        public string Result { get; set; } = String.Empty;
        public string FailedMessage { get; set; } = String.Empty;
    }
}
