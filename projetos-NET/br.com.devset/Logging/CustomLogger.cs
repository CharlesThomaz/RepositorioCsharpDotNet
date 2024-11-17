namespace br.com.devset.Logging
{
    public interface ICustomLogger
    {
        void Log(string message);
    }
    public class CustomLogger
    {
    }
    public class MockLogger : ICustomLogger
    {
        public void Log(string message) {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ICustomLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("File" + message);
        }
    }
}
