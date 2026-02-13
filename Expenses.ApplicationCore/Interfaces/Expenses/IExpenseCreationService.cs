using Expenses.ApplicationCore.Commands.Expenses.Create;
using Expenses.ApplicationCore.Entities;

namespace Expenses.ApplicationCore.Interfaces.Expenses;

internal interface IExpenseCreationService
{
    Task<Expense> Create(CreateExpenseCommand command, CancellationToken cancellationToken);
}