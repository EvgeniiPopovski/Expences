using CsvHelper.Configuration.Attributes;
using FileProcessor.Core.Enums;

namespace FileProcessor.Core.Models;

internal class ExpenseModel
{
    [Name("Category")]
    public ExpenseCategory Category { get; set; }

    [Name("Amount")]
    public decimal Amount { get; set; }

    [Name("Date of Creation")]
    public DateTime CreatedAt { get; set; }

    [Name("Comment")]
    public string Comment { get; set; }
}