using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Users;
using Expenses.Infrastructure.Database;
using Expenses.Infrastructure.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Infrastructure;

public static class ServicesInstaller
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        services.AddScoped<IJwtIssuer, JwtIssuer>();
        services.AddScoped<IUserLoginService, UserLoginService>();

        return services;
    }
}