using FileProcessor.Core.Enums;

namespace FileProcessor.Core.Entities;

public class Expense : BaseEntity
{
    public decimal Amount { get; set; }

    public string Name { get; set; }

    public ExpenseCategory Category { get; set; }

    public int OwnerId { get; set; }

    public string OwnerName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Comment { get; set; }
}