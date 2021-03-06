﻿using System;
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
            var resultsInRange = m_LogDbContext.ExecutedCommands.Where(x => x.ExecutedTime < minDate).Select(x => x.IdExecutedCommand).Take(50).ToArray();
            var treated = 0;
            while (resultsInRange.Any())
            {
                var nbResultsInRange = resultsInRange.Length;

                foreach (var c in resultsInRange)
                {
                    var entity = m_LogDbContext.ExecutedCommands.Find(c);
                    m_LogDbContext.ExecutedCommands.Remove(entity);
                }

                treated += nbResultsInRange;
                m_ExecutionLogService.Log($"{nbResultsInRange} log entries deleted ! Total : {treated}");
                m_LogDbContext.SaveChanges();

                resultsInRange = m_LogDbContext.ExecutedCommands.Where(x => x.ExecutedTime < minDate).Select(x => x.IdExecutedCommand).Take(50).ToArray();
            }

            m_LogDbContext.SaveChanges();
            m_ExecutionLogService.Log($"All The logs were deleted successfully !!");

            m_ExecutionLogService.Log($"=================================================================");
            return treated;
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
