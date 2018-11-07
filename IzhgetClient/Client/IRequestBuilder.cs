using System.Collections.Generic;
using System.Net.Http;

namespace Client
{
    public interface IRequestBuilder
    {
        HttpRequestMessage Build(Dictionary<string, string> parameters);
    }
}