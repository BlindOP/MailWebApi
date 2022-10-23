using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Models
{

    public static class SeedData
    {

        /// <summary>
        /// Create new database from migration if it doesn't exist 
        /// </summary>
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<MailDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        }
    }
}

