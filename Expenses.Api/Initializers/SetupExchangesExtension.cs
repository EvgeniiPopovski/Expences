using Expenses.ApplicationCore.Constants;
using Expenses.Infrastructure.Messaging;

namespace ExpensesApi.Initializers;

internal static class SetupExchangesExtension
{
    public static void SetupExchanges(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var factory = scope.ServiceProvider.GetRequiredService<RabbitMqConnectionFactory>();
            var connection = factory.GetConnection();
            var chanel = connection.CreateModel();

            foreach (var exchangeSettings in ExchangesConstants.Exchanges.All)
            {
                chanel.ExchangeDeclare(exchangeSettings.Name, exchangeSettings.Type, true, false, null);
                foreach (var queueSettings in exchangeSettings.QueueSettings)
                {
                    chanel.QueueDeclare(queueSettings.Name, true, false, false, null);
                    chanel.QueueBind(queueSettings.Name, exchangeSettings.Name, queueSettings.Key, null);
                }
            }
        }
    }
}