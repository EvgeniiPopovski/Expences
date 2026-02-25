using System.Text;
using System.Text.Json;
using FileProcessor.Infrastructure.Interfaces;

namespace FileProcessor.Infrastructure.Services;

internal class MessageSerializer : IMessageSerializer
{
    public T Deserialize<T>(ReadOnlySpan<byte> messageSpan)
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
        };

        var jsonString = Encoding.UTF8.GetString(messageSpan);
        return JsonSerializer.Deserialize<T>(jsonString, options);
    }
}