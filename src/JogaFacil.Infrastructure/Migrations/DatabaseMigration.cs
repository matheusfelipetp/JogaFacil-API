using JogaFacil.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JogaFacil.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static async Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<JogaFacilDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
