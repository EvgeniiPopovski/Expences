using Expenses.ApplicationCore.Constants;
using Expenses.ApplicationCore.Interfaces;
using Expenses.ApplicationCore.Interfaces.Expenses;
using Expenses.ApplicationCore.Interfaces.Messaging;
using MediatR;

namespace Expenses.ApplicationCore.Commands.Expenses.Create;

internal sealed class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IExpenseCreationService _expenseCreationService;
    private readonly IMessagePublisher _messagePublisher;

    public CreateExpenseCommandHandler(
        IApplicationDbContext context,
        IExpenseCreationService expenseCreationService,
        IMessagePublisher messagePublisher)
    {
        _context = context;
        _expenseCreationService = expenseCreationService;
    }

    public async Task Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
    {
        var expense = await _expenseCreationService.Create(command, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        await _messagePublisher.PublishAsync(expense, MessagingConstants.ExpensesExchange.Name, "expense.create", cancellationToken);
    }
}