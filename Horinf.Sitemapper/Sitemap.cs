using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Horinf.Sitemapper
{
    /// <summary>
    /// Representation of xml document (sitemap)
    /// </summary>
    public class Sitemap
    {
        internal Sitemap(XDocument xDocument)
        {
            XDocument = xDocument;
        }

        /// <summary>
        /// XML document.
        /// </summary>
        public XDocument XDocument { get; }

        public static implicit operator XDocument(Sitemap sitemap)
        {
            return sitemap.XDocument;
        }

        /// <summary>
        /// Convert xml document to bytes (e.g. to send as file)
        /// </summary>
        public byte[] ConvertToBytes()
        {
            byte[] imgByteArr;
            using (var ms = new MemoryStream())
            {
                XDocument.Save(ms);
                imgByteArr = ms.ToArray();
            }

            return imgByteArr;
        }

        /// <summary>
        /// Convert xml documetn to string
        /// </summary>
        /// <returns></returns>
        public string ConvertToString()
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                XDocument.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
