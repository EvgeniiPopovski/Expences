using FileProcessor.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Polly;

namespace FileProcessor.Infrastructure.Messaging;

public class RabbitMqPolicyFactory
{
    private readonly MessagingPolicySettings _policySettings;

    public RabbitMqPolicyFactory(IOptions<MessagingPolicySettings> settings)
    {
        _policySettings = settings.Value;
    }

    public IAsyncPolicy CreatePublishPolicy()
    {
        return Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(
                retryCount: _policySettings.RetryCount,
                sleepDurationProvider: _ => TimeSpan.FromMilliseconds(_policySettings.RetryDelayMilliseconds));
    }
}
