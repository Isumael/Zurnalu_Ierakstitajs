//paskaidrojums: a) Caulculator ir balstīts uz ILogger, jo tas seko SOLID D principam, ka kods balstās uz vairākiem maziem interfeisiem b) Lasīšana ir atsevišķā interfeisā pēc SOLID I principa.
public interface ILogger 
{  
void Log(string message);
}

public interface ILogReader 
{
List<string> GetMessages();
}


public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("[LOG] " + message);
    }
}


public class MemoryLogger : ILogger, ILogReader
{
    private readonly List<string> _messages = new List<string>();
    public void Log(string message)
    {
        _messages.Add(message);
    }
    public List<string> GetMessages()
    {
        return _messages;
    }
}


public class Calculator
{
    private readonly ILogger _logger;
    public Calculator(ILogger logger)
    {
        _logger = logger;
    }
    public int Add(int a, int b)
    {
        int sum = a + b;
        _logger.Log($"{a} + {b} = {sum}");
        return sum;
    }
}