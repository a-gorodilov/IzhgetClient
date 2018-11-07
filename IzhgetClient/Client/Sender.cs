using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class Sender : ISender
    {
        private readonly IRequestBuilder requestBuilder;

        public Sender(IRequestBuilder requestBuilder)
        {
            this.requestBuilder = requestBuilder;
        }
        
        public async Task<string> GetScheduleResponseText(Dictionary<string, string> parameters)
        {
            var request = requestBuilder.Build(parameters);

            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.SendAsync(request).ConfigureAwait(false);
            }

            if (!response.IsSuccessStatusCode)
            {
                return "Что-то пошло не так!";
            }

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}