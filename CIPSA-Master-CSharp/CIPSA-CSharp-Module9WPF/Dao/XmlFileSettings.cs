using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CIPSA_CSharp_Module9WPF.Dao
{
    public class XmlFileSettings
    {
        public static void XmlSettings(string path, string name)
        {
            var xmlSettings = new XmlWriterSettings
            {
                Indent = true,
                CheckCharacters = true,
                NewLineOnAttributes = true
            };
            using (var writer = XmlWriter.Create(path, xmlSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(name);
                writer.Flush();
            }
        }
    }
}
