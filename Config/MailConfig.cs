using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailWebApi.Config
{
    /// <summary>
    /// SMTP configuration
    /// </summary>
    public class MailConfig
    {
        /// <summary>
        /// SMTP Server adress
        /// </summary>
        public string Host { get; set; } = String.Empty;

        /// <summary>
        /// Port of the host SMTP Server 
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Email to connect SMTP Server
        /// </summary>
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// Password to connect SMTP Server
        /// </summary>
        public string Password { get; set; } = String.Empty;

        /// <summary>
        /// Use SSL to encrypt the connection
        /// </summary>
        public bool SSL { get; set; }
    }
}
