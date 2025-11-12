using Microsoft.Extensions.DependencyInjection;

namespace BudgetManager.Application.Container;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services;
}
