using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Expenses;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Create;

internal sealed class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IExpenseCreationService _expenseCreationService;

    public CreateExpenseCommandHandler(
        IApplicationDbContext context,
        IExpenseCreationService expenseCreationService)
    {
        _context = context;
        _expenseCreationService = expenseCreationService;
    }

    public async Task Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        await _expenseCreationService.Create(command, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}