using FileProcessor.Core.Interfaces;
using FileProcessor.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace FileProcessor.Infrastructure;

public static class ServiceInstaller
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();
        services.AddSingleton<RabbitMqConnectionFactory>();
        services.AddSingleton<RabbitMqPolicyFactory>();
    }
}