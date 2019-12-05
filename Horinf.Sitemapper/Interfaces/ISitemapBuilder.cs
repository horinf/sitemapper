using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Horinf.Sitemapper.Interfaces
{
    /// <summary>
    /// Sitemap builder.
    /// </summary>
    public interface ISitemapBuilder
    {
        /// <summary>
        /// Sitemap nodes.
        /// </summary>
        ConcurrentBag<SitemapNode> Nodes { get; }

        /// <summary>
        /// Easy way to add node.
        /// </summary>
        SitemapBuilder AddNode(string location);

        /// <summary>
        /// Add node.
        /// </summary>
        SitemapBuilder AddNode(SitemapNode node);

        /// <summary>
        /// Build the XML document based on added nodes.
        /// </summary>
        Sitemap Build();
    }
}
