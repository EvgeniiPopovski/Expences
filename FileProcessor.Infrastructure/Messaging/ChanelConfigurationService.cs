using FileProcessor.Infrastructure.Interfaces;
using RabbitMQ.Client;

namespace FileProcessor.Infrastructure.Messaging;

internal class ChanelConfigurationService : IChanelConfigurationService
{
    private readonly RabbitMqConnectionFactory _connectionFactory;

    public ChanelConfigurationService(RabbitMqConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IModel ConfigureChannel(string exchange, string queue, string routingKey)
    {
        var chanel = _connectionFactory.GetConnection().CreateModel();

        chanel.BasicQos(
            prefetchSize: 0,
            prefetchCount: 10,
            global: false);

        chanel.ExchangeDeclare(
            exchange: exchange,
            type: "direct",
            durable: true,
            autoDelete: false);

        chanel.QueueDeclare(
            queue: queue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        chanel.QueueBind(
            queue: queue,
            exchange: exchange,
            routingKey: routingKey);

        return chanel;
    }
}