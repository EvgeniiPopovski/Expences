using Expenses.ApplicationCore.Commands.Expenses.Create;
using Expenses.ApplicationCore.Entities;
using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Expenses;

namespace Expenses.ApplicationCore.Services.Expenses;

internal sealed class ExpenseCreationService : IExpenseCreationService
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextResolver _httpContextResolver;
    private readonly IExpenseCreationValidator _expenseCreationValidator;

    public ExpenseCreationService(
        IApplicationDbContext context,
        IHttpContextResolver httpContextResolver,
        IExpenseCreationValidator expenseCreationValidator)
    {
        _context = context;
        _httpContextResolver = httpContextResolver;
        _expenseCreationValidator = expenseCreationValidator;
    }

    public async Task<Expense> Create(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        if (!_expenseCreationValidator.IsValid(command))
        {
            throw new InvalidDataException("Invalid expense creation data.");
        }

        var expense = new Expense
        {
            Name = command.Name,
            Category = command.Category,
            OwnerId = _httpContextResolver.GetCurrentUserId()
        };

        await _context.Expenses.AddAsync(expense, cancellationToken);

        return expense;
    }
}