using MailWebApi.Config;
using MailWebApi.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MailWebApi.Services
{
    /// <summary>
    /// Service for sending an emails
    /// </summary>
    public class MailService : IMailService
    {
        private readonly MailConfig _config;
        public MailService(IOptions<MailConfig> mailConfig)
        {
            _config = mailConfig.Value;
        }
        /// <summary>
        /// Send Email to Recipients 
        /// </summary>
        public async Task<Mail> SendEmailAsync(MailRequestDTO mailBase)
        {
            SmtpClient smtp;
            MailMessage message = new MailMessage(); ;

            Mail mail = new Mail
            {
                Body = mailBase.Body,
                Subject = mailBase.Subject,
                Date = DateTime.Now,
                FailedMessage = "",
                Recipients = mailBase.Recipients.Select(x => new RecipientСlass() { Recipient = x }).ToList(),
                Result = "OK"
            };
            try
            {
                message.From = new MailAddress(_config.Email);
                foreach (var recipient in mail.Recipients)
                {
                    message.To.Add(recipient.Recipient);
                }

                message.Subject = mail.Subject;
                message.Body = mail.Body;
            }
            catch (Exception ex)
            {
                mail.FailedMessage = $"Forming message error: {ex.Message}";
            }
            try
            {
                smtp = new SmtpClient(_config.Host, _config.Port);
                smtp.Credentials = new NetworkCredential(_config.Email, _config.Password);
                smtp.EnableSsl = _config.SSL;
                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                mail.FailedMessage = $"Sending message error: {ex.Message}";
            }

            return mail;
        }
    }
}
