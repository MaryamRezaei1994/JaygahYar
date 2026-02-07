using StackExchange.Redis;

namespace JaygahYar.Application.Interfaces;

public interface ICacheProvider
{
    IDatabase Database { get; }
    IServer Server { get; }
}

