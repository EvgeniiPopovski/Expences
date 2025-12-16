using Expenses.ApplicationCore.Models;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Users.Registration;

public class UserRegistrationCommand : IRequest<Result>
{
    public UserRegistrationCommand(UserRegisterModel model)
    {
        Model = model;
    }
    public UserRegisterModel Model { get; set; }
}