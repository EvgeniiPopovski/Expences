using Expenses.ApplicationCore.Models;

namespace Expenses.ApplicationCore.Interfaces;

public interface IUserRegistrationService
{
    Task<Result> Register(UserRegisterModel model);
}