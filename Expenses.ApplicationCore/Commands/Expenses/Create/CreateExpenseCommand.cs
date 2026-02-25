using Expenses.ApplicationCore.Enums;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Create;

public struct CreateExpenseCommand(
    string name,
    ExpenseCategory category,
    decimal amount,
    string comment) : IRequest
{
    public string Name { get; init; } = name;

    public ExpenseCategory Category { get; init; } = category;

    public decimal Amount { get; init; } = amount;

    public string Comment { get; init; } = comment;
}