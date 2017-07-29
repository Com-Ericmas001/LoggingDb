using System;
using System.Diagnostics;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Com.Ericmas001.LoggingDb.Util
{
    public abstract class WebApiRequestAndResponseHandler : DelegatingHandler
    {
        protected abstract string ExtractParams(HttpRequestMessage request, string endpoint);
        protected abstract void Log(string clientIp, string userAgent, string service, string endpoint, string httpMethod, string parms, string requestContentType, string requestBody, string responseContentType, string responseBody, string responseCode);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(request, cancellationToken);

            try
            {
                const string API_MARKER = "api/";
                var url = request.RequestUri.ToString();
                var service = url.Remove(url.IndexOf(API_MARKER, StringComparison.Ordinal) + API_MARKER.Length);
                var endpoint = url.Substring(service.Length);

                string requestContentType = null;
                string requestBody = null;
                if (request.Content != null)
                {
                    if (request.Content.Headers?.ContentType != null)
                        requestContentType = request.Content.Headers.ContentType.ToString();
                    request.Content.ReadAsStreamAsync().Result.Seek(0, System.IO.SeekOrigin.Begin);
                    requestBody = await request.Content.ReadAsStringAsync();
                }

                string responseContentType = null;
                string responseBody = null;
                string responseCode = $"{(int)result.StatusCode} - {result.StatusCode}";
                if (result.Content != null)
                {
                    if (result.Content.Headers?.ContentType != null)
                        responseContentType = result.Content.Headers.ContentType.ToString();
                    responseBody = await result.Content.ReadAsStringAsync();
                }

                Log(GetClientIp(request), request.Headers.UserAgent.ToString(), service, endpoint, request.Method.ToString(), ExtractParams(request, endpoint), requestContentType, requestBody, responseContentType, responseBody, responseCode);

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }

            return result;
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.UserHostAddress;
            return null;
        }
    }
}
