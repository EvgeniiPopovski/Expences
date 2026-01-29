using Expenses.ApplicationCore.Extensions;
using Expenses.ApplicationCore.Interfaces;

namespace ExpensesApi.Services;

internal sealed class HttpContextResolver : IHttpContextResolver
{
    private const string IdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextResolver(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentUserId()
    {
        var claim = _httpContextAccessor.HttpContext.User.FindFirst(IdClaimType);

        return claim.Value.ToInteger();
    }
}