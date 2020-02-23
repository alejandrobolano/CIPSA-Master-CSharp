using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CIPSA_CSharp_Module9WPF.Logicals.Contract;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF.Dao
{
    public class SubjectXmlFile : IXmlFile<Subject>
    {

        public Subject Add(Subject subject)
        {
            try
            {
                if (!File.Exists(Utils.SUBJECTXML))
                {
                    XmlFileSettings.XmlSettings(Utils.SUBJECTXML, "Subjects");
                }
                AddNode(subject);
            }
            catch (Exception e)
            {
                //LOG.Error(e + subject.Name);
                throw;
            }
            return Get(subject.Id);
        }

        private void AddNode(Subject subject)
        {
            var xml = XDocument.Load(Utils.SUBJECTXML);
            var subjects = xml.Element("Subjects");
            subjects?.Add(
                new XElement("Subject",
                new XAttribute("Id", subject.Id),
                    new XElement("Name", subject.Name),
                    new XElement("Area", subject.Area)
                ));
            xml.Save(Utils.SUBJECTXML);
        }
        
        public Subject Get(Guid subjectId)
        {
            var xDoc = XDocument.Load(Utils.SUBJECTXML);
            var root = xDoc.Root;
            var subjectResult = new Subject();
            var subjectList = from element in root?.Elements("Subject")
                              where element.Attribute("Id").Value.Equals(subjectId.ToString())
                              select element;
            ConvertXElementToSubject(subjectResult, subjectList.First());

            return subjectResult;
        }

        public List<Subject> GetAll()
        {
            var subjectList = new List<Subject>();
            if (!File.Exists(Utils.SUBJECTXML))
            {
                XmlFileSettings.XmlSettings(Utils.SUBJECTXML, "Subjects");
            }
            else
            {
                var xDoc = XDocument.Load(Utils.SUBJECTXML);
                var root = xDoc.Root;
                var subjectElements = from element in root?.Elements("Subject")
                    select element;
                foreach (var element in subjectElements)
                {
                    var subjectTemp = new Subject();
                    ConvertXElementToSubject(subjectTemp, element);
                    subjectList.Add(subjectTemp);
                }
            }

            return subjectList;
        }

        public Subject Update(Subject subject)
        {
            var xDoc = XDocument.Load(Utils.SUBJECTXML);
            var subjectXml = xDoc.Descendants("Subject");
            var element = FindElement(subject.Id, subjectXml);
            UpdateElement(subject, xDoc, element);

            return Get(subject.Id);
        }

        public void Remove(Guid genericId)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<XElement> FindElement(Guid subjectId, IEnumerable<XElement> subjectXml)
        {
            return from subject in subjectXml
                   where new Guid(subject.Attribute("Id")?.Value) == subjectId
                select subject;
        }

        private void UpdateElement(Subject subject, XDocument xDoc, IEnumerable<XElement> element)
        {
            var updateSubject = element.First();
            updateSubject.Element("Name").Value = subject.Name;
            updateSubject.Element("Area").Value = subject.Area;
            xDoc.Save(Utils.SUBJECTXML);
        }

        private void ConvertXElementToSubject(Subject subjectResult, XElement subjectElement)
        {
            subjectResult.Id = new Guid(subjectElement.Attribute("Id")?.Value);
            subjectResult.Name = subjectElement.Element("Name")?.Value;
            subjectResult.Area = subjectElement.Element("Area")?.Value;
        }

    }
}
