using System;
using System.IO;
using System.Xml;

namespace XML_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = Directory.GetCurrentDirectory() + @"\Test.xml";
            ManipulateXML myXML = new ManipulateXML(path);

            myXML.Add("PROJECT", "My Project", "Version", "1.0");
        }
    }
}
