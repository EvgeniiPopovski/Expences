using Expenses.ApplicationCore.Interfaces.Users;
using Expenses.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Expenses.Infrastructure.Identity.Services;

internal class UserLoginService : IUserLoginService
{
    private readonly UserManager<IdentityApplicationUser> _userManager;
    private readonly IJwtIssuer _jwtIssuer;

    public UserLoginService(UserManager<IdentityApplicationUser> userManager, IJwtIssuer jwtIssuer)
    {
        _userManager = userManager;
        _jwtIssuer = jwtIssuer;
    }

    public async Task<Result<string>> Login(UserLoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.UserName);
        if (user == null)
        {
            return Result<string>.Failed("Email or password is incorrect.");
        }
        
        var result = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!result)
        {
            return Result<string>.Failed("Email or password is incorrect.");
        }

        return Result<string>.Success(_jwtIssuer.IssueToken(user.ToUserModel()));
    }
}