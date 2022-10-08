using MailWebApi.Models;

namespace MailWebApi.Services
{
    public interface IMailService
    {
        public Task<Mail> SendEmailAsync(MailRequestDTO mailBase);
    }
}
