using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.Extensions;
using CIPSA_CSharp_Module11.Extra.Enum;
using PersonCommon = CIPSA_CSharp_Module11.Common.Models.Person;


namespace CIPSA_CSharp_Module11.Extra.Models
{
    public class Employer : PersonCommon
    {
        public WorkShiftEnum WorkShift { get; set; }
        public int NumberEmployer { get; set; }

        public Employer(string name, string lastName, WorkShiftEnum workShift, int numberEmployer)
        {
            Name = name;
            LastName = lastName;
            WorkShift = workShift;
            NumberEmployer = numberEmployer;
        }

        public override string ToString()
        {
            return $"Nombre completo: {Name} {LastName}" +
                   $"\tHorario de trabajo: {WorkShift.GetDescription()}" +
                   $"\tNúmero de empleado: {NumberEmployer}";
        }
    }
}
