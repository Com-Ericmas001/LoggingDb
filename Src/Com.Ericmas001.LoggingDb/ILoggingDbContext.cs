using Com.Ericmas001.LoggingDb.Entities;
using System.Data.Entity;
// ReSharper disable All

namespace Com.Ericmas001.LoggingDb
{
    public interface ILoggingDbContext
    {
        IDbSet<Client> Clients { get; set; }
        IDbSet<ExecutedCommand> ExecutedCommands { get; set; }
        IDbSet<ServiceMethod> ServiceMethods { get; set; }

        int SaveChanges();
    }
}
