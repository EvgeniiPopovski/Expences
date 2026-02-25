namespace FileProcessor.Infrastructure.Interfaces;

internal interface IMessageSerializer
{
    T Deserialize<T>(ReadOnlySpan<byte> messageSpan);
}