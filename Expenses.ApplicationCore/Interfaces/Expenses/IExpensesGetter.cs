using Expenses.ApplicationCore.Models.Expenses;

namespace Expenses.ApplicationCore.Interfaces.Expenses;

internal interface IExpensesGetter
{
    Task<ICollection<ExpenseModel>> GetExpenses(CancellationToken cancellationToken);
}