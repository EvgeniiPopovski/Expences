namespace FileProcessor.Infrastructure.Settings;

public class RabbitMqSettings
{
    public string HostName { get; init; }

    public int Port { get; init; }

    public string UserName { get; init; }

    public string Password { get; init; }

    public string VirtualHost { get; init; }

    public string DefaultExchange { get; init; }
}