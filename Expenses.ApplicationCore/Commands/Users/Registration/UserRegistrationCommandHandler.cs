using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Models;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Users.Registration;

internal class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, Result>
{
    private readonly IUserRegistrationService _userRegistrationService;

    public UserRegistrationCommandHandler(IUserRegistrationService userRegistrationService)
    {
        _userRegistrationService = userRegistrationService;
    }

    public Task<Result> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        return _userRegistrationService.Register(request.Model);
    }
}