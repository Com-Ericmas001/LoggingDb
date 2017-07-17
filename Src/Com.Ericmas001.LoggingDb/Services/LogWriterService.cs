using System;
using System.Diagnostics;
using System.Linq;
using Com.Ericmas001.LoggingDb.Entities;
using Com.Ericmas001.LoggingDb.Services.Interfaces;

namespace Com.Ericmas001.LoggingDb.Services
{
    public class LogWriterService : ILogWriterService
    {
        private readonly ILoggingDbContext m_DbContext;

        public LogWriterService(ILoggingDbContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public void LogExecutedCommand(string clientIp, string clientUserAgent, string serviceName, string controllerName, string methodName, string parms, string requestContentType, string requestData, string responseContentType, string responseData, string responseCode)
        {
            try
            {
                var service = m_DbContext.ServiceMethods.FirstOrDefault(x => x.ServiceName == serviceName && x.ControllerName == controllerName && x.MethodName == methodName) ?? new ServiceMethod
                {
                    ServiceName = serviceName,
                    ControllerName = controllerName,
                    MethodName = methodName
                };

                var client = m_DbContext.Clients.FirstOrDefault(x => x.IpAddress == clientIp && x.UserAgent == clientUserAgent) ?? new Client
                {
                    IpAddress = clientIp,
                    UserAgent = clientUserAgent
                };

                m_DbContext.ExecutedCommands.Add(new ExecutedCommand
                {
                    ServiceMethod = service,
                    Client = client,
                    Parms = parms,
                    RequestContentType = requestContentType,
                    RequestData = requestData,
                    ResponseContentType = responseContentType,
                    ResponseData = responseData,
                    ResponseCode = responseCode
                });

                m_DbContext.SaveChanges();

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }
    }
}
