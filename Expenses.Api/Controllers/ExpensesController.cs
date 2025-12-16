using ExpensesApi.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Controllers;

public class ExpensesController : BaseController
{
    public ExpensesController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpGet]
    public Task<string> GetExpenses()
    {
        return Task.FromResult("Expenses");
    }

    [HttpGet(Routes.Expenses.GetById)]
    public Task<string> GetExpensesById(int id)
    {
        return Task.FromResult(id.ToString());
    }
}