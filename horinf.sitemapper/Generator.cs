using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace horinf.sitemapper
{
    public class Generator
    {
        public static XDocument GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Loc)));

                if (sitemapNode.Lastmod != null)
                {
                    var dt = (DateTime)sitemapNode.Lastmod;
                    var sb = new StringBuilder();
                    sb.Append(dt.Year);
                    sb.Append("-");
                    sb.Append(dt.Month);
                    sb.Append("-");
                    sb.Append(dt.Day);
                    urlElement.Add(new XElement(xmlns + "lastmod", sb.ToString()));
                }

                if (sitemapNode.Changefreq != null)
                {
                    urlElement.Add(new XElement(xmlns + "changefreq", (ChangefreqEnum)sitemapNode.Changefreq));
                }

                if (sitemapNode.Priority != null)
                {
                    if (sitemapNode.Priority > 1)
                        sitemapNode.Priority = 1;
                    if (sitemapNode.Priority < 0)
                        sitemapNode.Priority = 0;

                    urlElement.Add(new XElement(xmlns + "priority", Math.Round((decimal)sitemapNode.Priority, 1)));
                }
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document;
        }
    }

}
