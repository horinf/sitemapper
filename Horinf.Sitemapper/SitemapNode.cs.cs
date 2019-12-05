using System;

namespace Horinf.Sitemapper
{
    /// <summary>
    /// Node in sitemap.
    /// </summary>
    public class SitemapNode
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="location">Resource (page) url.</param>
        public SitemapNode(string location)
        {
            Location = location;
        }

        /// <summary>
        /// Number to sort nodes in file (if null -- order is not supported)
        /// </summary>
        public int SortNumber { get; set; }

        /// <summary>
        /// Resource (page) url.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Last modification date.
        /// </summary>
        public DateTime? LastModificationDate { get; set; }

        /// <summary>
        /// Change Frequency (how often you do some changes in this page)
        /// </summary>
        public ChangefreqEnum? ChangeFrequency { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public decimal? Priority { get; set; }
    }
}
