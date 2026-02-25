using FileProcessor.Core.Interfaces;
using FileProcessor.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FileProcessor.Infrastructure.Messaging;

public class RabbitMqConsumer<T> : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string _queueName;
    private readonly string _exchangeName;
    private readonly string _routingKey;
    private IModel _channel;
    private IServiceScope _mainScope;

    public RabbitMqConsumer(
        IServiceProvider serviceProvider,
        string exchangeName,
        string queueName,
        string routingKey)
    {
        _serviceProvider = serviceProvider;
        _queueName = queueName;
        _exchangeName = exchangeName;
        _routingKey = routingKey;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _mainScope = _serviceProvider.CreateScope();
        _channel = _mainScope.ServiceProvider.GetRequiredService<IChanelConfigurationService>()
            .ConfigureChannel(_exchangeName, _queueName, _routingKey);

        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (_, args) =>
        {
            try
            {
                await ProcessMessage<T>(args, stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                _channel.BasicNack(
                    args.DeliveryTag,
                    false,
                    requeue: false);
            }
        };

        _channel.BasicConsume(
            queue: _queueName,
            autoAck: false,
            consumer: consumer);

        return Task.CompletedTask;
    }
    
    private async Task ProcessMessage<T>(BasicDeliverEventArgs args, CancellationToken cancellationToken)
    {
        var message = _mainScope.ServiceProvider.GetRequiredService<IMessageSerializer>()
            .Deserialize<T>(args.Body.Span);

        if (message == null)
        {
            throw new NullReferenceException("Message is null");
        }

        var handler = _mainScope.ServiceProvider
            .GetRequiredService<IMessageEventHandler<T>>();

        await handler.HandleAsync(message, cancellationToken);

        _channel.BasicAck(args.DeliveryTag, false);
    }

    public override void Dispose()
    {
        _mainScope.Dispose();
        _channel.Close();
        _channel.Dispose();
        base.Dispose();
    }
}