using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Client
{
    public class RequestBuilder : IRequestBuilder
    {
        public HttpRequestMessage Build(Dictionary<string, string> parameters)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, IzhgetRequestParams.Url);
            
            var parametersString = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
            
            httpRequestMessage.Content = new StringContent(parametersString);
            httpRequestMessage.Headers.Add("Content-Type", IzhgetRequestParams.ContentType);

            return httpRequestMessage;
        }
    }
}