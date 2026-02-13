using Expenses.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApi.Initializers;

internal static class DatabaseMigrationExtension
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}