using FileProcessor.Core.Events;
using FileProcessor.Core.Interfaces;
using FileProcessor.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FileProcessor.Core;

public static class ServiceInstaller
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageEventHandler<ExpenseCreatedEvent>, ExpenseCreatedHandler>();
    }
}