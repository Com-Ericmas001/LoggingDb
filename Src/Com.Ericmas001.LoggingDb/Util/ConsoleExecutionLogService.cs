using System;

namespace Com.Ericmas001.LoggingDb.Util
{
    public class ConsoleLoggingExecutionLogService : ILoggingExecutionLogService
    {
        public void Log(string message)
        {
#if DEBUG
            message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
#endif
            Console.WriteLine(message);
        }
    }
}
