using Expenses.ApplicationCore.Commands.Users.Login;
using Expenses.ApplicationCore.Commands.Users.Registration;
using Expenses.ApplicationCore.Models;
using ExpensesApi.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Controllers;

public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpPost(Routes.Users.Register)]
    public Task<Result> Register([FromBody] UserRegisterModel request)
    {
        return Mediator.Send(new UserRegistrationCommand(request));
    }

    [AllowAnonymous]
    [HttpPost(Routes.Users.Login)]
    public Task<Result<string>> Login([FromBody] UserLoginModel request)
    {
        return Mediator.Send(new UserLoginCommand(request));
    }
}