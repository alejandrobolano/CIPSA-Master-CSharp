using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.School.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual string GetInfo()
        {
            return "Nombre: " + Name +
                   "\n Apellidos: " + LastName;
        }
    }
}
