using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BudgetManager.Infrastructure.Data.Context;

namespace BudgetManager.Infrastructure.Data;

public static class DatabaseConfigurator
{
    public static IServiceCollection AddSqlLiteDb(this IServiceCollection services)
        => services.AddDbContext<AppDbContext>(o =>
            o.UseSqlite("Data Source=budgetmanager.db"));
}