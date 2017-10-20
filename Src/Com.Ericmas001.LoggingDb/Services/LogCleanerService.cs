using System;
using System.Linq;
using Com.Ericmas001.LoggingDb.Services.Interfaces;

namespace Com.Ericmas001.LoggingDb.Services
{
    public class LogCleanerService : ILogCleanerService
    {
        private readonly ILoggingDbContext m_LogDbContext;

        public LogCleanerService(ILoggingDbContext logDbContext)
        {
            m_LogDbContext = logDbContext;
        }

        public int RemoveLogsOlderThan(DateTime minDate)
        {
            var logsToRemove = m_LogDbContext.ExecutedCommands.Where(x => x.ExecutedTime < minDate).ToArray();

            foreach (var log in logsToRemove)
                m_LogDbContext.ExecutedCommands.Remove(log);

            m_LogDbContext.SaveChanges();

            return logsToRemove.Length;
        }

        public int RemoveUnusedClients()
        {
            var clientsToRemove = m_LogDbContext.Clients.Where(x => !x.ExecutedCommands.Any()).ToArray();

            foreach (var c in clientsToRemove)
                m_LogDbContext.Clients.Remove(c);

            m_LogDbContext.SaveChanges();

            return clientsToRemove.Length;
        }

        public int RemoveUnusedServices()
        {
            var servicesToRemove = m_LogDbContext.ServiceMethods.Where(x => !x.ExecutedCommands.Any()).ToArray();

            foreach (var s in servicesToRemove)
                m_LogDbContext.ServiceMethods.Remove(s);

            m_LogDbContext.SaveChanges();

            return servicesToRemove.Length;
        }
    }
}
