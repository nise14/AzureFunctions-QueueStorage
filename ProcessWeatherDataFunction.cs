using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WeatherDataIngestor
{
    public class ProcessWeatherDataFunction
    {
        private readonly IMessageProcessor _messageProcessor;
        private readonly IAnotherDependency _anotherDependency;
        private readonly ILogger<ProcessWeatherDataFunction> _logger;

        public ProcessWeatherDataFunction(IMessageProcessor messageProcessor, 
            IAnotherDependency anotherDependency,
            ILogger<ProcessWeatherDataFunction> logger)
        {
            _messageProcessor = messageProcessor;
            _anotherDependency = anotherDependency;
            _logger = logger;
        }

        [FunctionName("ProcessWeatherData")]
        public void Run([QueueTrigger("add-weatherdata", Connection = "WeatherDataQueue")] string myQueueItem)
        {
            _messageProcessor.Process(myQueueItem);
            _anotherDependency.Process(myQueueItem);
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
