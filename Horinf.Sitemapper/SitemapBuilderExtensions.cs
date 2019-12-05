using System.Threading.Tasks;
using Horinf.Sitemapper.Checker;

namespace Horinf.Sitemapper
{
    /// <summary>
    /// Extensions to work with Sitemap builder
    /// </summary>
    public static class SitemapBuilderExtensions
    {
        /// <summary>
        /// Check sitemap nodes using sitemap checker.
        /// </summary>
        public static async Task Check(this SitemapBuilder sitemapBuilder, SitemapChecker checker)
        {
            await checker.Check(sitemapBuilder.Nodes);
        }
    }
}
