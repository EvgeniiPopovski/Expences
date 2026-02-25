using CsvHelper.Configuration.Attributes;
using FileProcessor.Core.Entities;
using FileProcessor.Core.Enums;

namespace FileProcessor.Core.Models;

public class ExpenseModel
{
    public int Id { get; set; }

    [Name("Category")]
    public ExpenseCategory Category { get; set; }
    
    [Name("Title")]
    public string Name { get; set; }

    [Name("Amount")]
    public decimal Amount { get; set; }

    [Name("Date of Creation")]
    public DateTime CreatedAt { get; set; }

    [Name("Comment")]
    public string Comment { get; set; }

    public int OwnerId { get; set; }

    public string OwnerName { get; set; }

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