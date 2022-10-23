using System.ComponentModel.DataAnnotations;

namespace MailWebApi.Models
{
    /// <summary>
    /// POST request data object
    /// </summary>
    public class MailRequestDTO
    {
        [Required]
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
        public List<string> Recipients { get; set; } = new();

    }
    /// <summary>
    /// Response data object
    /// </summary>
    public class MailDTO
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<string> Recipients { get; set; } = new();
        public DateTime Date { get; set; } 
        public string Result { get; set; } = string.Empty;
        public string FailedMessage { get; set; } = string.Empty;
    }
}
