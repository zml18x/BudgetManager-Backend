using Serilog;
using Scalar.AspNetCore;
using BudgetManager.Application.Container;
using BudgetManager.Infrastructure.Container;
using BudgetManager.Infrastructure.Data;
using BudgetManager.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGroup("auth")
    .MapIdentityApi<User>();

app.MapControllers();

app.Services.MigrateDatabase();

app.Run();