using BudgetManager.Infrastructure.Data;
using BudgetManager.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Infrastructure.Container;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddSqlLiteDb()
            .AddIdentity();
}