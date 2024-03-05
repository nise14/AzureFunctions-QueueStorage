namespace WeatherDataIngestor;

public interface IAnotherDependency
{
    void Process(string message);
}

public class AnotherDependency : IAnotherDependency
{
     private readonly ITransientService _transientService;
    private readonly ISingletonService _singletonService;
    private readonly IScopedService _scopedService;

    public AnotherDependency(ITransientService transientService,
        ISingletonService singletonService,
        IScopedService scopedService)
    {
        _transientService = transientService;
        _singletonService = singletonService;
        _scopedService = scopedService;
    }

    public void Process(string message)
    {
        _transientService.Write("Another Dependency");
        _scopedService.Write("Another Dependency");
        _singletonService.Write("Another Dependency");
    }
}

