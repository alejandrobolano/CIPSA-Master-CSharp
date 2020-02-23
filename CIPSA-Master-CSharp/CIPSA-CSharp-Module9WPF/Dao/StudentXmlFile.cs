using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CIPSA_CSharp_Module9WPF.Logicals.Contract;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF.Dao
{
    public class StudentXmlFile : IXmlFile<Student>
    {
        public Student Add(Student student)
        {
            try
            {
                if (!File.Exists(Utils.STUDENTXML))
                {
                    XmlFileSettings.XmlSettings(Utils.STUDENTXML, "Students");
                }
                AddNode(student);
            }
            catch (Exception e)
            {
                //LOG.Error(e + student.Name);
                throw;
            }
            return Get(student.Id);
        }

        private void AddNode(Student student)
        {
            var xml = XDocument.Load(Utils.STUDENTXML);
            var students = xml.Element("Students");
            students?.Add(
                new XElement("Student",
                new XAttribute("Id", student.Id),
                    new XElement("Name", student.Name),
                    new XElement("LastName", student.LastName),
                    new XElement("Sex", student.Sex),
                    new XElement("Age", Convert.ToString(student.Age)),
                    new XElement("ExamNote", Convert.ToString(student.ExamNote))
                ));
            xml.Save(Utils.STUDENTXML);
        }

        public Student Get(Guid studentId)
        {
            var xDoc = XDocument.Load(Utils.STUDENTXML);
            var root = xDoc.Root;
            var studentResult = new Student();
            var studentList = from element in root?.Elements("Student")
                              where element.Attribute("Id").Value.Equals(studentId.ToString())
                              select element;
            if (studentList.ToList().Any())
            {
                ConvertXElementToStudent(studentResult, studentList.First());
            }

            return studentResult;
        }
        public List<Student> GetAll()
        {
            var studentList = new List<Student>();
            if (!File.Exists(Utils.STUDENTXML))
            {
                XmlFileSettings.XmlSettings(Utils.STUDENTXML, "Students");
            }
            else
            {
                var xDoc = XDocument.Load(Utils.STUDENTXML);
                var root = xDoc.Root;
                var studentElements = from element in root?.Elements("Student")
                    select element;
                foreach (var element in studentElements)
                {
                    var studentTemp = new Student();
                    ConvertXElementToStudent(studentTemp, element);
                    studentList.Add(studentTemp);
                }
            }

            return studentList;
        }

        private void ConvertXElementToStudent(Student studentResult, XElement studentElement)
        {
            studentResult.Id = new Guid(studentElement.Attribute("Id")?.Value);
            studentResult.Name = studentElement.Element("Name")?.Value;
            studentResult.LastName = studentElement.Element("LastName")?.Value;
            studentResult.Sex = Convert.ToChar(studentElement.Element("Sex")?.Value);
            studentResult.Age = Convert.ToInt32(studentElement.Element("Age")?.Value);
            studentResult.ExamNote = Convert.ToInt32(studentElement.Element("ExamNote")?.Value);
        }

        public Student Update(Student student)
        {
            var xDoc = XDocument.Load(Utils.STUDENTXML);
            var studentXml = xDoc.Descendants("Student");
            var element = FindElement(student.Id, studentXml);
            UpdateElement(student, xDoc, element);

            return Get(student.Id);
        }

        public void Remove(Guid genericId)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<XElement> FindElement(Guid studentId, IEnumerable<XElement> studentXml)
        {
            return from student in studentXml
                where new Guid(student.Attribute("Id")?.Value) == studentId
                select student;
        }

        private void UpdateElement(Student student, XDocument xDoc, IEnumerable<XElement> element)
        {
            var updateStudent = element.First();
            updateStudent.Element("Name").Value = student.Name;
            updateStudent.Element("LastName").Value = student.LastName;
            updateStudent.Element("Age").Value = student.Age.ToString();
            updateStudent.Element("Sex").Value = student.Sex.ToString();
            updateStudent.Element("ExamNote").Value = student.ExamNote.ToString();
            xDoc.Save(Utils.STUDENTXML);
        }

    }
}
