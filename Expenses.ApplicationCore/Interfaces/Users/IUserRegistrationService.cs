using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Interfaces.Users;

public interface IUserRegistrationService
{
    Task<Result> Register(UserRegisterModel model);
}