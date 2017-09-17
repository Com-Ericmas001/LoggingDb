using System;

namespace Com.Ericmas001.LoggingDb.Services.Interfaces
{
    public interface ILogCleanerService
    {
        int RemoveLogsOlderThan(DateTime minDate);
        int RemoveUnusedClients();
        int RemoveUnusedServices();
    }
}
