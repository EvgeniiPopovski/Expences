using Expenses.ApplicationCore.Enums;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Create;

public struct CreateExpenseCommand(string name, ExpenseCategory category) : IRequest
{
    public string Name { get; init; } = name;

    public ExpenseCategory Category { get; init; } = category;
}