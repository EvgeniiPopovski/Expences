using Expenses.ApplicationCore.Enums;

namespace Expenses.ApplicationCore.Entities;

public class Expense
{
    public string Id { get; set; }

    public string Name { get; set; }

    public ExpenseCategory Category { get; set; }
}