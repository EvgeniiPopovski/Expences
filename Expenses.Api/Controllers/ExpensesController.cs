using Expenses.ApplicationCore.Commands.Expenses.Create;
using Expenses.ApplicationCore.Commands.Expenses.Get;
using Expenses.ApplicationCore.Models.Expenses;
using ExpensesApi.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Controllers;

[Authorize]
public class ExpensesController : BaseController
{
    public ExpensesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public Task<ICollection<ExpenseModel>> GetExpenses(CancellationToken cancellationToken)
    {
        return Mediator.Send(new GetExpensesCommand(), cancellationToken);
    }

    [HttpGet(Routes.Expenses.GetById)]
    public Task<string> GetExpensesById(int id)
    {
        return Task.FromResult(id.ToString());
    }

    [HttpPost]
    public Task CreateExpenses(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        return Mediator.Send(command, cancellationToken);
    }
}