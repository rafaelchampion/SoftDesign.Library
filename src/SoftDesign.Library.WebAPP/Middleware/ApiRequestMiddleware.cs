using System.Collections.Generic;
using System.Configuration;
using RestSharp;

namespace SoftDesign.Library.WebAPP.Middleware
{
    public static class ApiRequestMiddleware
    {
        private static readonly string ApiBaseUrl = ConfigurationManager.AppSettings.Get("BaseApiUrl");

        public static RestRequest CreateRequest(string endpoint,
                                                Method method,
                                                string token = null,
                                                object body = null,
                                                IDictionary<string, object> parameters = null)
        {
            var request = new RestRequest(endpoint, method);
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);
                }
            }
            if (body != null && method != Method.GET)
            {
                request.AddJsonBody(body);
            }
            return request;
        }

        public static RestClient CreateClient()
        {
            return new RestClient(ApiBaseUrl);
        }
    }
}