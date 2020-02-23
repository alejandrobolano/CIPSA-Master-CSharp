using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF.Logicals.Contract
{
    interface IStudentSubjectXmlFile : IXmlFile<StudentSubject>
    {
        List<StudentSubject> GetAllByStudent(Guid id);
        List<StudentSubject> GetAllBySubject(Guid id);
        void Remove(Guid subjectId, Guid studentId);
    }
}
