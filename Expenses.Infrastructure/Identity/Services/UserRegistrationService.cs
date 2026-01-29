using Expenses.ApplicationCore.Entities;
using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Users;
using Expenses.ApplicationCore.Models;
using Expenses.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;

namespace Expenses.Infrastructure.Identity.Services;

internal sealed class UserRegistrationService : IUserRegistrationService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;

    public UserRegistrationService(
        UserManager<IdentityApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Register(UserRegisterModel model)
    {
        var user = new AppUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            CreatedAt = DateTime.UtcNow,
        };

        var identityUser = new IdentityApplicationUser()
        {
            UserName = model.Email,
            Email = model.Email,
            User = user,
        };
        
        var result = await _userManager.CreateAsync(identityUser, model.Password);

        return new Result()
        {
            IsSucceeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description).ToList(),
        };
    }
}