using LogicService;
using Microsoft.EntityFrameworkCore;

public static class DatabaseMigrator
{
    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.Migrate();
        }
    }
}