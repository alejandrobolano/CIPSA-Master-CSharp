using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.Common.Models;

namespace CIPSA_CSharp_Module11.School.Models
{
    public class Teacher : Person
    {
        public int ClassroomAssigned { get; set; }
        public bool IsTutor { get; set; }

        public Teacher(string name, string lastName, int classroomAssigned, bool isTutor)
        {
            Name = name;
            LastName = lastName;
            ClassroomAssigned = classroomAssigned;
            IsTutor = isTutor;
        }

        public override string GetBasicInfo()
        {
            var tutor = IsTutor ? "El profesor es tutor" : "El profesor no es tutor";
            return base.GetBasicInfo() +
                   "\n Aula asignada: " + ClassroomAssigned +
                   "\n " + tutor;
        }
    }
}
