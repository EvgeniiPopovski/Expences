namespace Expenses.ApplicationCore.Interfaces;

public interface IHttpContextResolver
{
    int GetCurrentUserId();
}