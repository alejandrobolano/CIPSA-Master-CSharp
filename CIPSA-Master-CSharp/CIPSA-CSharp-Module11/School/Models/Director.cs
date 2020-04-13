using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.Common.Models;

namespace CIPSA_CSharp_Module11.School.Models
{
    public class Director : Person
    {
        public int Antiquity { get; set; }
        public string School { get; set; }

        public Director(string name, string lastName, int antiquity, string school)
        {
            Name = name;
            LastName = lastName;
            Antiquity = antiquity;
            School = school;
        }

        public override string GetBasicInfo()
        {
            return base.GetBasicInfo() + 
                "\n Antigüedad: " + Antiquity + 
                "\n Colegio: " + School;
        }
    }
}
