using Com.Ericmas001.LoggingDb.Entities;
using System.Data.Entity;
using Microsoft.Practices.Unity;

// ReSharper disable All
namespace Com.Ericmas001.LoggingDb
{
    public class LoggingDbContext : DbContext, ILoggingDbContext
    {
        public LoggingDbContext(string connString)
            : base(connString)
        {
        }

        [InjectionConstructor]
        public LoggingDbContext()
            : base("name=LoggingDbContext")
        {
        }

        public virtual IDbSet<Client> Clients { get; set; }
        public virtual IDbSet<ExecutedCommand> ExecutedCommands { get; set; }
        public virtual IDbSet<ServiceMethod> ServiceMethods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.ExecutedCommands)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceMethod>()
                .HasMany(e => e.ExecutedCommands)
                .WithRequired(e => e.ServiceMethod)
                .WillCascadeOnDelete(false);
        }
    }
}
