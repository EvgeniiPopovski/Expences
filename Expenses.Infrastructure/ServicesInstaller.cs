using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Messaging;
using Expenses.ApplicationCore.Interfaces.Users;
using Expenses.Infrastructure.Database;
using Expenses.Infrastructure.Identity.Services;
using Expenses.Infrastructure.Messaging;
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

        services.AddSingleton<RabbitMqConnectionFactory>();
        services.AddSingleton<RabbitMqPolicyFactory>();
        services.AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();

        return services;
    }
}