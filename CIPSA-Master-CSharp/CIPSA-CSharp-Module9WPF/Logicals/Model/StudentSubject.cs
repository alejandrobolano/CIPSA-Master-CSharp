using System;

namespace CIPSA_CSharp_Module9WPF.Logicals.Model
{
    public class StudentSubject
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        
        public StudentSubject(Guid studentId, Guid subjectId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            SubjectId = subjectId;
        }

        public StudentSubject()
        {
        }
    }
}
