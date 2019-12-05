using System.Threading.Tasks;
using Horinf.Sitemapper.Interfaces;

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
        public static async Task Check(this ISitemapBuilder sitemapBuilder, ISitemapChecker checker)
        {
            await checker.Check(sitemapBuilder.Nodes);
        }
    }
}
