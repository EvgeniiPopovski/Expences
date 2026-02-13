using Expenses.ApplicationCore.Constants;
using Expenses.Infrastructure.Messaging;
using ExpensesApi.Constants;

namespace ExpensesApi.Initializers;

internal static class SetupExchangesExtension
{
    public static void SetupExchanges(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var factory = scope.ServiceProvider.GetRequiredService<RabbitMqConnectionFactory>();
            using var connection = factory.GetConnection();

            foreach (var exchangeSettings in MessagingConstants.All)
            {
                var chanel = connection.CreateModel();
                chanel.ExchangeDeclare(exchangeSettings.Name, exchangeSettings.Type, true, false, null);
            }
        }
    }
}