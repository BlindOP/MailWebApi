using Microsoft.EntityFrameworkCore;

namespace MailWebApi.Models {

    public static class SeedData {

        /// <summary>
        /// Create new datanase from migration if it doesn't exist 
        /// </summary>
        public static void EnsurePopulated(IApplicationBuilder app) {
            MailDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<MailDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            }
        }
    }

