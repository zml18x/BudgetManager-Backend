using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using BudgetManager.Infrastructure.Data.Context;

namespace BudgetManager.Infrastructure.Data;

public static class DatabaseMigrator
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            Log.Information("Starting database migration...");
            context.Database.Migrate();
            Log.Information("Migration completed successfully.");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unexpected error during migration: {Message}", ex.Message);
        }

        return serviceProvider;
    }
}