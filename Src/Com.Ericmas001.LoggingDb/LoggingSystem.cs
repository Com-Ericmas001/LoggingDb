using Com.Ericmas001.LoggingDb.Services;
using Com.Ericmas001.LoggingDb.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace Com.Ericmas001.LoggingDb
{
    public class LoggingDbSystem
    {
        private readonly IUnityContainer m_Container;

        public LoggingDbSystem(IUnityContainer container = null)
        {
            m_Container = container ?? new UnityContainer();

            RegisterTypes();
        }

        private void RegisterTypes()
        {
            m_Container.RegisterType<ILoggingDbContext, LoggingDbContext>();

            m_Container.RegisterType<ILogWriterService, LogWriterService>();
        }

        public void LogExecutedCommand(string clientIp, string clientUserAgent, string serviceName, string controllerName, string methodName, string parms, string requestContentType, string requestData, string responseContentType, string responseData, string responseCode)
        {
            m_Container.Resolve<ILogWriterService>().LogExecutedCommand(clientIp, clientUserAgent, serviceName, controllerName, methodName, parms, requestContentType, requestData, responseContentType, responseData, responseCode);
        }
    }
}
