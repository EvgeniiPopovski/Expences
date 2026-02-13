using System.Text.Json;
using FileProcessor.Core.Interfaces;
using Polly;
using RabbitMQ.Client;

namespace FileProcessor.Infrastructure.Messaging;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    private readonly RabbitMqConnectionFactory _connectionFactory;
    private readonly IAsyncPolicy _publishPolicy;
    private readonly JsonSerializerOptions _jsonOptions;

    public RabbitMqMessagePublisher(
        RabbitMqConnectionFactory connectionFactory,
        RabbitMqPolicyFactory policyFactory)
    {
        _connectionFactory = connectionFactory;
        _publishPolicy = policyFactory.CreatePublishPolicy();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }

    public async Task PublishAsync<T>(
        T message,
        string exchange,
        string routingKey,
        CancellationToken cancellationToken = default)
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
            var properties = CreateProperties(channel);

            channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: properties,
                body: messageBody);

            await Task.CompletedTask;
        });
    }

    private IBasicProperties CreateProperties(IModel channel)
    {
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        properties.ContentType = "application/json";
        properties.MessageId = Guid.NewGuid().ToString();
        properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

        return properties;
    }
}
