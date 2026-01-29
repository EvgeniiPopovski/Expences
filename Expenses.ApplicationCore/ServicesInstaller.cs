using System.Reflection;
using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Expenses;
using Expenses.ApplicationCore.Services.Expenses;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.ApplicationCore;

public static class ServicesInstaller
{
    public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IExpensesGetter, ExpensesGetter>();
        services.AddScoped<IExpenseCreationService, ExpenseCreationService>();
        services.AddScoped<IExpenseCreationValidator, ExpenseCreationValidator>();

        return services;
    }
}