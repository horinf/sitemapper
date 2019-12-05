using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Horinf.Sitemapper.Interfaces;

namespace Horinf.Sitemapper.Checker
{
    /// <inheritdoc />
    public class SitemapChecker : ISitemapChecker
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SitemapChecker()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Constructor to create SitemapChecker with custom http client.
        /// </summary>
        public SitemapChecker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task Check(IEnumerable<SitemapNode> sitemapNodes)
        {
            var exceptions = new List<SitemapCheckException>();
            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(sitemapNode.Location);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    exceptions.Add(new SitemapCheckException(sitemapNode.Location, ex));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new SitemapCheckAggregateException(exceptions);
            }
        }
    }
}
