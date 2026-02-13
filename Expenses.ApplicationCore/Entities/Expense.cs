using Expenses.ApplicationCore.Enums;

namespace Expenses.ApplicationCore.Entities;

// TODO: Add property: decimal Amount, string Comment
public class Expense
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ExpenseCategory Category { get; set; }
    
    public int OwnerId { get; set; }

    public virtual AppUser Owner { get; set; }
}