using Expenses.ApplicationCore.Commands.Expenses.Create;
using Expenses.ApplicationCore.Extensions;
using Expenses.ApplicationCore.Interfaces.Expenses;

namespace Expenses.ApplicationCore.Services.Expenses;

internal sealed class ExpenseCreationValidator : IExpenseCreationValidator
{
    public bool IsValid(CreateExpenseCommand command)
    {
        return command.Name.IsNotNullOrEmpty() && command.Name.Length < 200;
    }
}