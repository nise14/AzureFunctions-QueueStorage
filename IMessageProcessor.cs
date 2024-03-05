namespace WeatherDataIngestor;

public interface IMessageProcessor
{
    void Process(string message);
}