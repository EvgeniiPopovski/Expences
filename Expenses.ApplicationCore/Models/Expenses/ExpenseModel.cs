using Expenses.ApplicationCore.Entities;
using Expenses.ApplicationCore.Enums;

namespace Expenses.ApplicationCore.Models.Expenses;

public class ExpenseModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ExpenseCategory Category { get; set; }

    public static ExpenseModel MapFromEntity(Expense expense)
    {
        return new ExpenseModel()
        {
            Id = expense.Id,
            Name = expense.Name,
            Category = expense.Category,
        };
    }
}