using Expenses.ApplicationCore.Models.Expenses;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Get;

public class GetExpensesCommand : IRequest<ICollection<ExpenseModel>>;