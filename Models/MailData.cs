using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Models
{
    public class MailData : IDataStorage<Mail>
    {

        private MailDbContext context;
        public MailData(MailDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all messages from DB
        /// </summary>
        public async Task<IEnumerable<Mail>> GetAllAsync()
        {
            var mails = await context.Mail.AsNoTracking().ToListAsync();
            return mails;
        }


        /// <summary>
        /// Add message to DB
        /// </summary>
        public async Task AddAsync(Mail item)
        {
           await context.Mail.AddAsync(item);
           await context.SaveChangesAsync();
        }

    }
}
