using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Constants;

public static class MessagingConstants
{
    public static Exchange ExpensesExchange = new() { Name = "expenses", Type = "topic" };

    public static Exchange ReportsExchange = new() { Name = "reports", Type = "topic" };

    public static ICollection<Exchange> All => new List<Exchange>
    {
        ExpensesExchange, ReportsExchange,
    };
}