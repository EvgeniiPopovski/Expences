using Expenses.ApplicationCore.Interfaces.Users;
using Expenses.ApplicationCore.Models;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Users.Login;

internal class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<string>>
{
    private readonly IUserLoginService _userLoginService;

    public UserLoginCommandHandler(IUserLoginService userLoginService)
    {
        _userLoginService = userLoginService;
    }

    public Task<Result<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        return _userLoginService.Login(request.Model);
    }
}