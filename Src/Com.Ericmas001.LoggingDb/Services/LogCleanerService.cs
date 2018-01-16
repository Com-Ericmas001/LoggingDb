using System;
using System.Linq;
using Com.Ericmas001.LoggingDb.Services.Interfaces;
using Com.Ericmas001.LoggingDb.Util;

namespace Com.Ericmas001.LoggingDb.Services
{
    public class LogCleanerService : ILogCleanerService
    {
        private readonly ILoggingDbContext m_LogDbContext;
        private readonly ILoggingExecutionLogService m_ExecutionLogService;

        public LogCleanerService(ILoggingDbContext logDbContext, ILoggingExecutionLogService executionLogService)
        {
            m_LogDbContext = logDbContext;
            m_ExecutionLogService = executionLogService;
        }

        public int RemoveLogsOlderThan(DateTime minDate)
        {
            m_LogDbContext.SetCommandTimeout(3600);

            m_ExecutionLogService.Log($"=================================================================");
            m_ExecutionLogService.Log($"Deleting logs older than {minDate:yyyy-MM-dd HH:mm:ss}");
            var nbResults = m_LogDbContext.ExecutedCommands.Count();
            var resultsInRange = m_LogDbContext.ExecutedCommands.Where(x => x.ExecutedTime < minDate).Select(x => x.IdExecutedCommand).ToArray();
            var nbResultsInRange = resultsInRange.Length;
            m_ExecutionLogService.Log($"{nbResultsInRange} of {nbResults} log entries are older than {minDate:yyyy-MM-dd HH:mm:ss} ...");
            var logsToRemove = m_LogDbContext.ExecutedCommands.Where(x => x.ExecutedTime < minDate).Select(x => x.IdExecutedCommand).ToArray();
            var i = 0;
            foreach (var c in resultsInRange)
            {
                m_LogDbContext.ExecutedCommands.Remove(m_LogDbContext.ExecutedCommands.Find(c));
                i++;
                if (i % 50 == 0)
                {
                    m_ExecutionLogService.Log($"{i} / {nbResultsInRange} log entries deleted ({(i * 100.0 / nbResultsInRange):0.00}%)");
                    m_LogDbContext.SaveChanges();
                }
            }

            m_LogDbContext.SaveChanges();
            m_ExecutionLogService.Log($"The logs were deleted successfully !!");

            m_ExecutionLogService.Log($"=================================================================");
            return logsToRemove.Length;
        }

        public int RemoveUnusedClients()
        {
            m_LogDbContext.SetCommandTimeout(3600);
            var clientsToRemove = m_LogDbContext.Clients.Where(x => !x.ExecutedCommands.Any()).ToArray();

            foreach (var c in clientsToRemove)
                m_LogDbContext.Clients.Remove(c);

            m_LogDbContext.SaveChanges();

            return clientsToRemove.Length;
        }

        public int RemoveUnusedServices()
        {
            m_LogDbContext.SetCommandTimeout(3600);
            var servicesToRemove = m_LogDbContext.ServiceMethods.Where(x => !x.ExecutedCommands.Any()).ToArray();

            foreach (var s in servicesToRemove)
                m_LogDbContext.ServiceMethods.Remove(s);

            m_LogDbContext.SaveChanges();

            return servicesToRemove.Length;
        }
    }
}
