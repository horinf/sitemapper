using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace Horinf.Sitemapper
{
    public class SitemapDocumentBuilder
    {
        private readonly ConcurrentBag<SitemapNode> _nodes;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SitemapDocumentBuilder()
        {
            _nodes = new ConcurrentBag<SitemapNode>();
        }

        /// <summary>
        /// Easy way to add node.
        /// </summary>
        public SitemapDocumentBuilder AddNode(string location)
        {
            _nodes.Add(new SitemapNode(location));
            return this;
        }

        /// <summary>
        /// Add node.
        /// </summary>
        public SitemapDocumentBuilder AddNode(SitemapNode node)
        {
            _nodes.Add(node);
            return this;
        }

        /// <summary>
        /// Build the XML document based on added nodes.
        /// </summary>
        public Sitemap Build()
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in _nodes.OrderBy(x => x.SortNumber))
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Location)));

                if (sitemapNode.LastModificationDate != null)
                {
                    var dt = (DateTime) sitemapNode.LastModificationDate;
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
                    urlElement.Add(new XElement(xmlns + "changefreq", (ChangefreqEnum) sitemapNode.ChangeFrequency));
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

                    urlElement.Add(new XElement(xmlns + "priority", Math.Round((decimal) sitemapNode.Priority, 1)));
                }

                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);

            return new Sitemap(document);
        }
    }
}
