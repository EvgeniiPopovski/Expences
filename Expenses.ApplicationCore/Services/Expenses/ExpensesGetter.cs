using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Expenses;
using Expenses.ApplicationCore.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace Expenses.ApplicationCore.Services.Expenses;

internal sealed class ExpensesGetter : IExpensesGetter
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextResolver _httpContextResolver;

    public ExpensesGetter(
        IApplicationDbContext context,
        IHttpContextResolver httpContextResolver)
    {
        _context = context;
        _httpContextResolver = httpContextResolver;
    }

    public async Task<ICollection<ExpenseModel>> GetExpenses(CancellationToken cancellationToken)
    {
        var currentUserId = _httpContextResolver.GetCurrentUserId();
        var expenses = await _context.Expenses
            .Where(e => e.OwnerId == currentUserId)
            .ToListAsync(cancellationToken);

        return expenses.Select(ExpenseModel.MapFromEntity).ToList();
    }
}