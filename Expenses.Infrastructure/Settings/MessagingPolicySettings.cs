namespace Expenses.Infrastructure.Settings;

public class MessagingPolicySettings
{
    public int RetryCount { get; init; }

    public int RetryDelayMilliseconds { get; init; }
}
