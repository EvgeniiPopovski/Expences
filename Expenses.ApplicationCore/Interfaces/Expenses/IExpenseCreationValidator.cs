using Expenses.ApplicationCore.Commands.Expenses.Create;

namespace Expenses.ApplicationCore.Interfaces.Expenses;

internal interface IExpenseCreationValidator
{
    bool IsValid(CreateExpenseCommand command);
}