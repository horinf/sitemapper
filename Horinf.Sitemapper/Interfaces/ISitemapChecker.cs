using System.Collections.Generic;
using System.Threading.Tasks;

namespace Horinf.Sitemapper.Interfaces
{
    /// <summary>
    /// Sitemap checker.
    /// </summary>
    public interface ISitemapChecker
    {
        /// <summary>
        /// Checks all sitemaps node location (one by one, next one only if previous is success).
        /// Server should return success status code. Otherwise an exception will be thrown.
        /// Use it inside try/catch block.
        /// </summary>
        Task Check(IEnumerable<SitemapNode> sitemapNodes);
    }
}
