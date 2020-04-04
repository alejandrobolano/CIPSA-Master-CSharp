using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.LivingOrganism.Models
{
    public class Cat : Animal
    {
        private string Breed { get; set; }

        public Cat(string scientificName, string food, int velocity, string breed)
        {
            ScientificName = scientificName;
            Food = food;
            Velocity = velocity;
            Breed = breed;
        }

        public override string ToString()
        {
            var space = " ";
            return base.ToString() + space +
                   "Raza: " + Breed;
        }
    }
}
