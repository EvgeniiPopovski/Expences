namespace FileProcessor.Core.Interfaces;

public interface IMessageEventHandler<T>
{
    Task HandleAsync(T message, CancellationToken cancellationToken);
}