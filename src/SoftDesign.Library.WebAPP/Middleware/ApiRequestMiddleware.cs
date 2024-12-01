using System.Configuration;
using RestSharp;

namespace SoftDesign.Library.WebAPP.Middleware
{
    public static class ApiRequestMiddleware
    {
        private static readonly string ApiBaseUrl = ConfigurationManager.AppSettings.Get("BaseApiUrl");

        public static RestRequest CreateRequest(string endpoint, Method method, string token = null)
        {
            var request = new RestRequest(endpoint, method);
            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", $"Bearer {token}");
            }
            return request;
        }

        public static RestClient CreateClient()
        {
            return new RestClient(ApiBaseUrl);
        }
    }
}