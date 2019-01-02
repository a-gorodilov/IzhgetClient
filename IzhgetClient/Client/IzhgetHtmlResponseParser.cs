using System;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;

namespace Client
{
    public class IzhgetHtmlResponseParser
    {
        public static RouteData[] Parse(string html)
        {
            var cleanHtml = html.Replace("\n", "");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(cleanHtml);
            
            var routeNodes = htmlDocument.DocumentNode.Descendants("tr").ToList();

            var routesInfoText = routeNodes
                .Select(x => x.ChildNodes.Nodes().Select(y => y.InnerText).ToArray());
            
            var routeData = routesInfoText
                .Where(x => x.Length == 4)    // base route-data array length
                .Select(x => new RouteData
                {
                    RouteNumber = int.Parse(x[0]),
                    DateFrom = ConvertIzhgetTime(x[2]),
                    DateTo = ConvertIzhgetTime(x[3]),
                }).ToArray();

            return routeData;
        }

        private static DateTime ConvertIzhgetTime(string timeString)
        {
            return DateTime.ParseExact(timeString, "HH:mm", CultureInfo.InvariantCulture);
        }
    }
}