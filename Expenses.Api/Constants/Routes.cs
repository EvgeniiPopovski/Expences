namespace ExpensesApi.Constants;

public class Routes
{
    public static class Expenses
    {
        public const string GetExpenses = "expenses";
        public const string GetById = "{id}";
    }

    public static class Users
    {
        public const string Register = "register";
        public const string Login = "login";
    }
}