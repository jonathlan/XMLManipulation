using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XML_Manipulation
{
    class ManipulateXML
    {
        XmlDocument doc;

        public string FileName
        { get; set; }

        public ManipulateXML(string fileName)
        {
            FileName = fileName;
            doc = new XmlDocument();

            CreateFile();
        }

        private void CreateFile()
        {
            if (!File.Exists(FileName))
            {
                using FileStream fs = File.Create(FileName);            
                    Byte[] info = new UTF8Encoding(true).GetBytes("<?xml version=\"1.0\" ?>\n<root>\n</root>");
                    fs.Write(info, 0, info.Length);                
            }

            doc.Load(FileName);
        }
        public void Add(string element, string innerText, string attribute, string value)
        {
            XmlNode root = doc.DocumentElement;
            XmlElement elem = doc.CreateElement(element);
            XmlAttribute attr = doc.CreateAttribute(attribute);
            attr.Value = value;
            elem.Attributes.Append(attr);
            elem.InnerText = innerText;
            root.InsertAfter(elem, root.LastChild);
            doc.Save(FileName);
        } 
    }
}
