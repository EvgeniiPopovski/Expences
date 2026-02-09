using System.Text;
using System.Text.Json;
using Expenses.ApplicationCore.Interfaces.Messaging;
using Expenses.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Polly;
using RabbitMQ.Client;

namespace Expenses.Infrastructure.Messaging;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    private readonly RabbitMqConnectionFactory _connectionFactory;
    private readonly RabbitMqSettings _settings;
    private readonly IAsyncPolicy _publishPolicy;
    private readonly JsonSerializerOptions _jsonOptions;

    public RabbitMqMessagePublisher(
        RabbitMqConnectionFactory connectionFactory,
        IOptions<RabbitMqSettings> settings,
        RabbitMqPolicyFactory policyFactory)
    {
        _connectionFactory = connectionFactory;
        _settings = settings.Value;
        _publishPolicy = policyFactory.CreatePublishPolicy();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }

    public async Task PublishAsync<T>(T message, string exchange, string routingKey, CancellationToken cancellationToken = default)
        where T : class
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        if (string.IsNullOrWhiteSpace(exchange))
        {
            throw new ArgumentException("Exchange name cannot be null or empty.", nameof(exchange));
        }

        if (string.IsNullOrWhiteSpace(routingKey))
        {
            throw new ArgumentException("Routing key cannot be null or empty.", nameof(routingKey));
        }

        await _publishPolicy.ExecuteAsync(async () =>
        {
            var connection = _connectionFactory.GetConnection();
            using var channel = connection.CreateModel();

            var messageBody = JsonSerializer.SerializeToUtf8Bytes(message, _jsonOptions);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            properties.ContentType = "application/json";
            properties.MessageId = Guid.NewGuid().ToString();
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: properties,
                body: messageBody);

            await Task.CompletedTask;
        });
    }
}
