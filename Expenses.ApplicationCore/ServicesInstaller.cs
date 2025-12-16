using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.ApplicationCore;

public static class ServicesInstaller
{
    public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}