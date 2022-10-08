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
        public async Task<IQueryable<Mail>> GetAllAsync()
        {
            var mails = await context.Mail.ToListAsync();
            return mails.AsQueryable();
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
