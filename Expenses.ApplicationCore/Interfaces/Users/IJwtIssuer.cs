using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Interfaces.Users;

public interface IJwtIssuer
{
    string IssueToken(UserModel model);
}