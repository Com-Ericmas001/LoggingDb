using Com.Ericmas001.LoggingDb.Services;
using Com.Ericmas001.LoggingDb.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace Com.Ericmas001.LoggingDb
{
    public static class LoggingDbUnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterTypes(IUnityContainer container = null)
        {
            Container = container ?? new UnityContainer();

            Container.RegisterType<ILoggingDbContext, LoggingDbContext>();

            Container.RegisterType<ILogWriterService, LogWriterService>();
        }
    }
}
