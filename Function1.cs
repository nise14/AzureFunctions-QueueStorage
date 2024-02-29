using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WeatherDataIngestor
{
    public class Function1
    {
        [FunctionName("ProcessWeatherData")]
        public void Run([QueueTrigger("add-weatherdata", Connection = "WeatherDataQueue")] string myQueueItem, ILogger log)
        {
            if (myQueueItem.Contains("exception"))
            {
                throw new Exception("Exception found in message");
            }
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
