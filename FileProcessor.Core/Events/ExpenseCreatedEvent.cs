using FileProcessor.Core.Entities;
using FileProcessor.Core.Enums;

namespace FileProcessor.Core.Events;

public record ExpenseCreatedEvent(
    int Id,
    ExpenseCategory Category,
    string Name,
    decimal Amount,
    DateTime CreatedAt,
    string Comment,
    int OwnerId,
    string OwnerName)
{
    public Expense ToExpense()
    {
        return new Expense
        {
            Id = Id,
            Amount = Amount,
            Name = Name,
            Category = Category,
            OwnerId = OwnerId,
            OwnerName = OwnerName,
            CreatedAt = CreatedAt,
            Comment = Comment,
        };
    }
}