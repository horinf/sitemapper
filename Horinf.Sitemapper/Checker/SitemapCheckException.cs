using System;

namespace Horinf.Sitemapper.Checker
{
    /// <summary>
    /// An exception while sitemap checking.
    /// </summary>
    public class SitemapCheckException : Exception
    {
        /// <summary>
        /// Location caused exception.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="location">Location that has caused exception.</param>
        /// <param name="innerException">Inner exception.</param>
        public SitemapCheckException(string location, Exception innerException) : base($"Sitemap node '{location}' is wrong", innerException)
        {
            Location = location;
        }
    }
}
