# sitemapper

[![pipeline status](https://gitlab.com/horinf/sitemapper/badges/master/pipeline.svg)](https://gitlab.com/horinf/sitemapper/commits/master)

Helper to build sitemap.xml file

Sitemap will look like:
<?xml version="1.0" encoding="UTF-8"?>
    <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"> 
        <url>
            <loc>http://www.example.com/page1.html</loc>
            <lastmod>2005-01-01</lastmod>
            <changefreq>monthly</changefreq>
            <priority>0.8</priority>
        </url>
        ...
    </urlset>

An example:

        public byte[] CreateSitemapBytes()
        {
            var mapBuilder = new SitemapDocumentBuilder()
                .AddNode(new SitemapNode("http://mydomain.com/page1"))
                .AddNode(new SitemapNode("http://mydomain.com/page2"));

            Sitemap sitemap = mapBuilder.Build();
            //string str = sitemap.ConvertToString();
            byte[] bytes = sitemap.ConvertToBytes();
            return bytes;
        }

And you can load it as a file or save to server directly.