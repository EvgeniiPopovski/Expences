namespace Expenses.ApplicationCore.Constants;

public class QueuesConstants
{
    public static class CreateExpenses
    {
        public static string Queue = "expense.created";

        public static string RoutingKey = "expense.created";
    }

    public static class CreateReport
    {
        public static string Queue = "report.create";

        public static string RoutingKey = "report.create";
    }
}