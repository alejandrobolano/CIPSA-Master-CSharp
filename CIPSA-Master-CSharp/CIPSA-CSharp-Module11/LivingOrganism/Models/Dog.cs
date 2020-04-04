using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.LivingOrganism.Models
{
    public class Dog : Animal
    {
        private string Color { get; set; }

        public Dog(string scientificName, string food, int velocity, string color)
        {
            ScientificName = scientificName;
            Food = food;
            Velocity = velocity;
            Color = color;
        }

        public override string ToString()
        {
            var space = " ";
            return base.ToString() + space +
                "Color: " + Color ;
        }
    }
}
