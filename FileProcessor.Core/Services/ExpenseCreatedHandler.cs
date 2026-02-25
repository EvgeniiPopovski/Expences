using FileProcessor.Core.Events;
using FileProcessor.Core.Interfaces;

namespace FileProcessor.Core.Services;

internal class ExpenseCreatedHandler : IMessageEventHandler<ExpenseCreatedEvent>
{
    private readonly IFileProcessorContext _context;

    public ExpenseCreatedHandler(IFileProcessorContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(ExpenseCreatedEvent message, CancellationToken cancellationToken)
    {
        var expense = message.ToExpense();

        await _context.Expenses.AddAsync(expense, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}