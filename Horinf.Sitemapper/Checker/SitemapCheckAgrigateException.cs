using System;
using System.Collections.Generic;

namespace Horinf.Sitemapper.Checker
{
    /// <summary>
    /// Aggregate exception while sitemap checking.
    /// </summary>
    public class SitemapCheckAggregateException : Exception
    {
        /// <summary>
        /// Collection of SitemapCheckExceptions.
        /// </summary>
        public ICollection<SitemapCheckException> Exceptions;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="exceptions">Collection of SitemapCheckExceptions.</param>
        public SitemapCheckAggregateException(ICollection<SitemapCheckException> exceptions) : base("Sitemap is wrong")
        {
            Exceptions = exceptions;
        }
    }
}
