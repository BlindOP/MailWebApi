using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Models
{
    public class MailData : IDataStorage<Mail>
    {

        private readonly MailDbContext _context;
        public MailData(MailDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Get all messages from DB
        /// </summary>
        public async Task<IEnumerable<Mail>> GetAllAsync()
        {
            var mails = await _context!.Mail.AsNoTracking().ToListAsync();
            return mails;
        }


        /// <summary>
        /// Add message to DB
        /// </summary>
        public async Task AddAsync(Mail item)
        {
           await _context.Mail.AddAsync(item);
           await _context.SaveChangesAsync();
        }

    }
}
