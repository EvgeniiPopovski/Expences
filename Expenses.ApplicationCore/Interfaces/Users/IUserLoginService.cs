using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Interfaces.Users;

public interface IUserLoginService
{
    Task<Result<string>> Login(UserLoginModel model);
}