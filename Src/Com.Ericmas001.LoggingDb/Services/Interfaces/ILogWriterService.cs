using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ericmas001.LoggingDb.Services.Interfaces
{
    public interface ILogWriterService
    {
        void LogExecutedCommand(string clientIp, string clientUserAgent, string serviceName, string controllerName, string methodName, string parms, string requestContentType, string requestData, string responseContentType, string responseData, string responseCode);
    }
}
