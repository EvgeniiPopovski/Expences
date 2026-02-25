namespace FileProcessor.Infrastructure.Constants;

internal static class MessagingConstants
{
    public static class Expenses
    {
        public static string Exchange = "expenses.exchange";

        public static string Queue = "expense.created";

        public static string RoutingKey = "expense.created";
    }
}