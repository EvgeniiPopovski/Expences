using Expenses.ApplicationCore.Entities;
using Expenses.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Expenses.Infrastructure.Identity;

public sealed class IdentityApplicationUser : IdentityUser<int>
{
    public int? UserId { get; set; }

    public AppUser User { get; set; }

    public UserModel ToUserModel()
    {
        return new UserModel()
        {
            Email = Email,
            Id = UserId.Value,
        };
    }
}