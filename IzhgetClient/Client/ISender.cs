using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public interface ISender
    {
        Task<string> GetScheduleResponseText(Dictionary<string, string> parameters);
    }
}