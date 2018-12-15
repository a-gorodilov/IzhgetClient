using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public static class Sender
    {
        public static async Task<string> GetScheduleResponseText(Dictionary<string, string> parameters)
        {
            var request = RequestBuilder.Build(parameters);

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