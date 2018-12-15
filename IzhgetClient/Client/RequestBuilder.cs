using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Client
{
    public static class RequestBuilder
    {
        public static HttpRequestMessage Build(Dictionary<string, string> parameters)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, IzhgetRequestParams.Url);
            
            var parametersString = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
            
            httpRequestMessage.Content = new StringContent(parametersString, Encoding.UTF8, IzhgetRequestParams.ContentType);

            return httpRequestMessage;
        }
    }
}