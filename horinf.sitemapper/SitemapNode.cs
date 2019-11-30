using System;

namespace horinf.sitemapper
{
    public class SitemapNode
    {
        public string Loc { get; set; }
        public DateTime? Lastmod { get; set; }
        public ChangefreqEnum? Changefreq { get; set; }
        public decimal? Priority { get; set; }

        public SitemapNode(string loc)
        {
            this.Loc = loc;
        }
    }
}
