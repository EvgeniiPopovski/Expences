namespace Expenses.ApplicationCore.Models;

public class Exchange
{
    public string Name { get; init; }

    public string Type { get; init; }

    public ICollection<Queue> QueueSettings { get; init; }
}