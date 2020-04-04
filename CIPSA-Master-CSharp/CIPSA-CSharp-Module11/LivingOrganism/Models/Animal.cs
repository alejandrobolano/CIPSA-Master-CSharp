using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.LivingOrganism.Models
{
    public class Animal
    {
        public string ScientificName { get; set; }
        public string Food { get; set; }
        public int Velocity { get; set; }

        public Animal()
        {

        }

        public Animal(string scientificName, string food, int velocity)
        {
            ScientificName = scientificName;
            Food = food;
            Velocity = velocity;
        }

        public override string ToString()
        {
            var space = " ";
            return "Nombre científico: " + ScientificName + space +
                   "Alimentación: " + Food + space +
                   "Velocidad: " + Velocity;
        }

        public string GetRun()
        {
            return Velocity > 50 ? "Corre mucho" : "Corre poco";
        }

        public virtual string GetJump()
        {
            return Velocity > 50 ? "Salta mucho" : "Salta poco";
        }
    }
}
