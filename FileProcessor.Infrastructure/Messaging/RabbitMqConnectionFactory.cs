using System.Net.Sockets;
using FileProcessor.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace FileProcessor.Infrastructure.Messaging;

public class RabbitMqConnectionFactory : IDisposable
{
    private readonly RabbitMqSettings _settings;
    private IConnection? _connection;
    private readonly object _lockObject = new();
    private bool _disposed;

    public RabbitMqConnectionFactory(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }

    public IConnection GetConnection()
    {
        if (_connection?.IsOpen == true)
        {
            return _connection;
        }

        lock (_lockObject)
        {
            if (_connection?.IsOpen == true)
            {
                return _connection;
            }

            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _settings.HostName,
                    Port = _settings.Port,
                    UserName = _settings.UserName,
                    Password = _settings.Password,
                    VirtualHost = _settings.VirtualHost,
                    AutomaticRecoveryEnabled = true,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                    DispatchConsumersAsync = true,
                };

                _connection = factory.CreateConnection();

                return _connection;
            }
            catch (BrokerUnreachableException ex)
            {
                throw new InvalidOperationException($"Unable to connect to RabbitMQ at {_settings.HostName}:{_settings.Port}", ex);
            }
            catch (SocketException ex)
            {
                throw new InvalidOperationException($"Network error connecting to RabbitMQ at {_settings.HostName}:{_settings.Port}", ex);
            }
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        lock (_lockObject)
        {
            if (_disposed)
            {
                return;
            }

            _connection?.Close();
            _connection?.Dispose();
            _disposed = true;
        }
    }
}
