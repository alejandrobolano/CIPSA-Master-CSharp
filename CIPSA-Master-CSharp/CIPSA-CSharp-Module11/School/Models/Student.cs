using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.School.Models
{
    public class Student : Person
    {
        public decimal Mathematics { get; set; }
        public decimal Spanish { get; set; }
        public decimal English { get; set; }

        public Student(string name, string lastName, 
            decimal mathematics, decimal spanish, decimal english)
        {
            Name = name;
            LastName = lastName;
            Mathematics = mathematics;
            Spanish = spanish;
            English = english;
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                   "\n Nota de matemática: " + Mathematics +
                   "\n Nota de lengua: " + Spanish +
                   "\n Nota de inglés: " + English;
        }
    }
}
