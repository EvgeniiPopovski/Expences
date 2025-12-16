using Expenses.ApplicationCore.Models;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Users.Login;

public class UserLoginCommand : IRequest<Result<string>>
{
    public UserLoginCommand(UserLoginModel model)
    {
        Model = model;
    }

    public UserLoginModel Model { get; set; }
}