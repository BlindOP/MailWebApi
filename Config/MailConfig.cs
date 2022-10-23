
namespace MailWebApi.Config
{
    /// <summary>
    /// SMTP configuration
    /// </summary>
    public class MailConfig
    {
        /// <summary>
        /// SMTP Server address
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Port of the host SMTP Server 
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Email to connect SMTP Server
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Password to connect SMTP Server
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Use SSL to encrypt the connection
        /// </summary>
        public bool SSL { get; set; }
    }
}
