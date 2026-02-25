using RabbitMQ.Client;

namespace FileProcessor.Infrastructure.Interfaces;

public interface IChanelConfigurationService
{
    IModel ConfigureChannel(string exchange, string queue, string routingKey);
}