using Expenses.ApplicationCore.Interfaces.Expenses;
using Expenses.ApplicationCore.Models.Expenses;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Get;

internal sealed class GetExpensesCommandHandler : IRequestHandler<GetExpensesCommand, ICollection<ExpenseModel>>
{
    private readonly IExpensesGetter _expensesGetter;

    public GetExpensesCommandHandler(IExpensesGetter expensesGetter)
    {
        _expensesGetter = expensesGetter;
    }

    public Task<ICollection<ExpenseModel>> Handle(GetExpensesCommand request, CancellationToken cancellationToken)
    {
        return _expensesGetter.GetExpenses(cancellationToken);
    }
}