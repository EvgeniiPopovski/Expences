using Expenses.ApplicationCore.Enums;

namespace Expenses.ApplicationCore.Entities;

public class Expense
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Amount { get; set; }

    public ExpenseCategory Category { get; set; }
    
    public int OwnerId { get; set; }

    public virtual AppUser Owner { get; set; }

    public string Comment { get; set; }
}