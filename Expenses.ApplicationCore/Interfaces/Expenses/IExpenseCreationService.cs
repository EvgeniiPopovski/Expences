using Expenses.ApplicationCore.Commands.Expenses.Create;

namespace Expenses.ApplicationCore.Interfaces.Expenses;

internal interface IExpenseCreationService
{
    Task Create(CreateExpenseCommand command, CancellationToken cancellationToken);
}