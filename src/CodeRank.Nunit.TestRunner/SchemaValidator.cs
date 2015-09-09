using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

using NUnit.Framework;

namespace CodeRank.Nunit.TestRunner
{
    /// <summary>
    /// The schema validator.
    /// </summary>
    public class SchemaValidator
    {
        private XmlReaderSettings settings;
        private List<string> errors;

        public SchemaValidator(string schemaFile)
        {
            this.settings = new XmlReaderSettings();
            this.settings.ValidationType = ValidationType.Schema;
            this.settings.Schemas.Add(XmlSchema.Read(
                new StreamReader(schemaFile),
                new ValidationEventHandler(this.ValidationEventHandle)));
        }

        public string[] Errors
        {
            get { return this.errors.ToArray(); }
        }

        public bool Validate(string xmlFile)
        {
            return this.Validate(new StreamReader(xmlFile));
        }

        public bool Validate(TextReader rdr)
        {
            this.errors = new List<string>();
            
            XmlReader myXmlValidatingReader = XmlReader.Create(rdr, this.settings);

            try
            {
                // Read XML data
                while (myXmlValidatingReader.Read()) { }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                myXmlValidatingReader.Close();
            }

            return this.errors.Count == 0;
        }

        public void ValidationEventHandle(object sender, ValidationEventArgs args)
        {
            this.errors.Add(args.Message);
        }
    }
}
