using System.Linq;
using HtmlAgilityPack;

namespace Client
{
    public class IzhgetHtmlResponseParser : IIzhgetHtmlResponseParser
    {
        public RouteData[] Parse(string html)
        {
            var cleanHtml = html.Replace("\n", "");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(cleanHtml);
            
            var routeNodes = htmlDocument.DocumentNode.Descendants("tr").ToList();

            var routesInfoText = routeNodes
                .Select(x => x.ChildNodes.Nodes().Select(y => y.InnerText).ToArray());
            
            var routeDatas = routesInfoText
                .Where(x => x.Length == 4)
                .Select(x => new RouteData
                {
                    RouteNumber = int.Parse(x[0]),
                    DateFrom = x[2],
                    DateTo = x[3]
                }).ToArray();

            return routeDatas;
        }
    }
}