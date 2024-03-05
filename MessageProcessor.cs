using System;
using Microsoft.Extensions.Options;

namespace WeatherDataIngestor;

public class MessageProcessor : IMessageProcessor
{
    private readonly ITransientService _transientService;
    private readonly ISingletonService _singletonService;
    private readonly IScopedService _scopedService;
    private readonly IOptions<MyConfigOptions> _configOptions;

    public MessageProcessor(ITransientService transientService,
        ISingletonService singletonService,
        IScopedService scopedService,
        IOptions<MyConfigOptions> configOptions)
    {
        _transientService = transientService;
        _singletonService = singletonService;
        _scopedService = scopedService;
        _configOptions = configOptions;
    }

    public void Process(string message)
    {
        if (message.Contains("exception"))
        {
            throw new Exception("Exception found in message");
        }

        _transientService.Write("Message processor");
        _scopedService.Write("Message processor");
        _singletonService.Write("Message processor");
    }
}