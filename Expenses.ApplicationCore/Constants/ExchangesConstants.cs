using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Constants;

public static class ExchangesConstants
{
    public static class Exchanges
    {
        public static Exchange ExpensesExchange = new()
        {
            Name = "expenses.exchange",
            Type = "direct",
            QueueSettings = new List<Queue>()
            {
                new() { Name = QueuesConstants.CreateExpenses.Queue, Key = QueuesConstants.CreateExpenses.RoutingKey}
            }
        };

        public static Exchange ReportsExchange = new()
        {
            Name = "reports.exchange",
            Type = "direct",
            QueueSettings = new List<Queue>()
            {
                new() { Name = QueuesConstants.CreateReport.Queue, Key = QueuesConstants.CreateReport.RoutingKey}
            }
        };

        public static ICollection<Exchange> All => new List<Exchange>
        {
            ExpensesExchange, ReportsExchange,
        };
    }
}