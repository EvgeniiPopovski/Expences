using FileProcessor.Core.Events;
using FileProcessor.Infrastructure.Constants;
using FileProcessor.Infrastructure.Interfaces;
using FileProcessor.Infrastructure.Messaging;
using FileProcessor.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FileProcessor.Infrastructure;

public static class ServiceInstaller
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IChanelConfigurationService, ChanelConfigurationService>();
        services.AddScoped<IMessageSerializer, MessageSerializer>();
        services.AddSingleton<RabbitMqConnectionFactory>();
        services.AddSingleton<RabbitMqPolicyFactory>();

        services.AddHostedService((provider) => new RabbitMqConsumer<ExpenseCreatedEvent>(
            provider,
            MessagingConstants.Expenses.Exchange,
            MessagingConstants.Expenses.Queue,
            MessagingConstants.Expenses.RoutingKey));
    }
}