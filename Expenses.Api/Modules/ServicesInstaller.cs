using Expenses.ApplicationCore;
using Expenses.Infrastructure;

namespace ExpensesApi.Modules;

public static class ServicesInstaller
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddApplicationCoreServices();
        services.AddInfrastructureServices();
    }
}