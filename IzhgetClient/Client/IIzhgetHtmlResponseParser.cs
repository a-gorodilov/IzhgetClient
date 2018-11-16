namespace Client
{
    public interface IIzhgetHtmlResponseParser
    {
        RouteData[] Parse(string html);
    }
}