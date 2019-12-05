using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Horinf.Sitemapper.Interfaces;

namespace Horinf.Sitemapper
{
    /// <inheritdoc />
    public class SitemapBuilder : ISitemapBuilder
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SitemapBuilder()
        {
            Nodes = new ConcurrentBag<SitemapNode>();
        }

        /// <inheritdoc />
        public ConcurrentBag<SitemapNode> Nodes { get; }

        /// <inheritdoc />
        public SitemapBuilder AddNode(string location)
        {
            Nodes.Add(new SitemapNode(location));
            return this;
        }

        /// <inheritdoc />
        public SitemapBuilder AddNode(SitemapNode node)
        {
            Nodes.Add(node);
            return this;
        }

        /// <inheritdoc />
        public Sitemap Build()
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in Nodes.OrderBy(x => x.SortNumber))
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Location)));

                if (sitemapNode.LastModificationDate != null)
                {
                    var dt = (DateTime)sitemapNode.LastModificationDate;
                    var sb = new StringBuilder();
                    sb.Append(dt.Year);
                    sb.Append("-");
                    sb.Append(dt.Month);
                    sb.Append("-");
                    sb.Append(dt.Day);
                    urlElement.Add(new XElement(xmlns + "lastmod", sb.ToString()));
                }

                if (sitemapNode.ChangeFrequency != null)
                {
                    urlElement.Add(new XElement(xmlns + "changefreq", (ChangefreqEnum)sitemapNode.ChangeFrequency));
                }

                if (sitemapNode.Priority != null)
                {
                    if (sitemapNode.Priority > 1)
                    {
                        sitemapNode.Priority = 1;
                    }

                    if (sitemapNode.Priority < 0)
                    {
                        sitemapNode.Priority = 0;
                    }
                    urlElement.Add(new XElement(xmlns + "priority", Math.Round((decimal)sitemapNode.Priority, 1)));
                }
                root.Add(urlElement);
            }
            XDocument document = new XDocument(root);
            return new Sitemap(document);
        }
    }
}
