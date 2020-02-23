using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CIPSA_CSharp_Module9WPF.Logicals.Contract;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF.Dao
{
    public class StudentSubjectXmlFile : IStudentSubjectXmlFile
    {

        public StudentSubject Add(StudentSubject subject)
        {
            try
            {
                if (!File.Exists(Utils.STUDENT_SUBJECTXML))
                {
                    XmlFileSettings.XmlSettings(Utils.STUDENT_SUBJECTXML, "StudentSubjects");
                }
                AddNode(subject);
            }
            catch (Exception e)
            {
                //LOG.Error(e + student.Name);
                throw;
            }
            return Get(subject.Id);
        }

        private static void AddNode(StudentSubject studentSubject)
        {
            var xml = XDocument.Load(Utils.STUDENT_SUBJECTXML);
            var studentSubjects = xml.Element("StudentSubjects");
            studentSubjects?.Add(
                new XElement("StudentSubject",
                new XAttribute("Id", studentSubject.Id),
                    new XElement("StudentId", studentSubject.StudentId),
                    new XElement("SubjectId", studentSubject.SubjectId)
                ));
            xml.Save(Utils.STUDENT_SUBJECTXML);
        }

        public StudentSubject Get(Guid subjectId)
        {
            var xDoc = XDocument.Load(Utils.STUDENT_SUBJECTXML);
            var root = xDoc.Root;
            var studentSubjectResult = new StudentSubject();
            var studentSubjectList = from element in root?.Elements("StudentSubject")
                              where element.Attribute("Id").Value.Equals(subjectId.ToString())
                              select element;
            ConvertXElementToStudentSubject(studentSubjectResult, studentSubjectList.First());

            return studentSubjectResult;
        }

        public List<StudentSubject> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<StudentSubject> GetAllByStudent(Guid studentId)
        {
            var subjectList = new List<StudentSubject>();
            if (!File.Exists(Utils.STUDENT_SUBJECTXML))
            {
                XmlFileSettings.XmlSettings(Utils.STUDENT_SUBJECTXML, "StudentSubjects");
            }
            else
            {
                var xDoc = XDocument.Load(Utils.STUDENT_SUBJECTXML);
                var root = xDoc.Root;
                var subjectElements = from element in root?.Elements("StudentSubject")
                    where element.Element("StudentId").Value.Equals(studentId.ToString())
                    select element;
                if (subjectElements.ToList().Any())
                {
                    foreach (var element in subjectElements)
                    {
                        var subjectTemp = new StudentSubject();
                        ConvertXElementToStudentSubject(subjectTemp, element);
                        subjectList.Add(subjectTemp);
                    }
                }
                
            }

            return subjectList;
        }

        public List<StudentSubject> GetAllBySubject(Guid id)
        {
            throw new NotImplementedException();
        }

        public StudentSubject Update(StudentSubject generic)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid genericId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid subjectId, Guid studentId)
        {
            var xDoc = XDocument.Load(Utils.STUDENT_SUBJECTXML);
            var subjectXml = xDoc.Descendants("StudentSubject");
            var element = FindElement(subjectId, studentId, subjectXml);
            element.First().Remove();
            xDoc.Save(Utils.STUDENT_SUBJECTXML);
        }

        private IEnumerable<XElement> FindElement(Guid subjectId, Guid studentId, IEnumerable<XElement> subjectXml)
        {
            return from subject in subjectXml
                where new Guid(subject.Element("SubjectId")?.Value) == subjectId 
                      && new Guid(subject.Element("StudentId")?.Value) == studentId
                   select subject;
        }

        private static void ConvertXElementToStudentSubject(StudentSubject studentSubjectResult, XElement studentSubject)
        {
            studentSubjectResult.Id = new Guid(studentSubject.Attribute("Id")?.Value);
            studentSubjectResult.StudentId = new Guid(studentSubject.Element("StudentId")?.Value);
            studentSubjectResult.SubjectId = new Guid(studentSubject.Element("SubjectId")?.Value);
        }

    }
}
