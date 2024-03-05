using System;
using Microsoft.Extensions.Logging;

namespace WeatherDataIngestor;

public interface ITransientService
{
    void Write(string message);
}

public interface IScopedService
{
    void Write(string message);
}

public interface ISingletonService
{
    void Write(string message);
}

public class TransientService : ITransientService
{
    public string Random { get; }

    private readonly ILogger<TransientService> _logger;

    public TransientService(ILogger<TransientService> logger)
    {
        Random = Guid.NewGuid().ToString();
        _logger = logger;
    }

    public void Write(string message)
    {
        _logger.LogInformation("Transient - {message}, {Random}", message, Random);
    }
}

public class SingletonService : ISingletonService
{
    public string Random { get; }

    private readonly ILogger<SingletonService> _logger;

    public SingletonService(ILogger<SingletonService> logger)
    {
        Random = Guid.NewGuid().ToString();
        _logger = logger;
    }

    public void Write(string message)
    {
        _logger.LogInformation("Singleton - {message}, {Random}", message, Random);
    }
}

public class ScopedService : IScopedService
{
    public string Random { get; }

    private readonly ILogger<ScopedService> _logger;

    public ScopedService(ILogger<ScopedService> logger)
    {
        Random = Guid.NewGuid().ToString();
        _logger = logger;
    }

    public void Write(string message)
    {
        _logger.LogInformation("Scoped - {message}, {Random}", message, Random);
    }
}