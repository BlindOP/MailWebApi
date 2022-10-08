using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Models {
    public class MailDbContext : DbContext {

        public MailDbContext(DbContextOptions<MailDbContext> options): base(options) { }

        public DbSet<Mail> Mail { get; set; }
        public DbSet<RecipientСlass> Recipient { get; set; }
    }
}
