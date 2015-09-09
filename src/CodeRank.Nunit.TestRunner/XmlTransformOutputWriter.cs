using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace CodeRank.Nunit.TestRunner
{
    public class XmlTransformOutputWriter
    {
        private string xsltFile;
        private XslCompiledTransform transform = new XslCompiledTransform();

        public XmlTransformOutputWriter(string xsltFile)
        {
            this.xsltFile = xsltFile;
            this.transform.Load(xsltFile);
        }

        public void WriteResultFile(XmlNode result, TextWriter writer)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(writer))
            {
                xmlWriter.Formatting = Formatting.Indented;
                this.transform.Transform(result, xmlWriter);
            }
        }

        public void WriteResultFile(XmlNode result, string outputPath)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(outputPath, Encoding.Default))
            {
                xmlWriter.Formatting = Formatting.Indented;
                this.transform.Transform(result, xmlWriter);
            }
        }
    }
}
