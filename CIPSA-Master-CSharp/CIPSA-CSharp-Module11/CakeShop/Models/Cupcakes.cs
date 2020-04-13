using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.CakeShop.Enums;

namespace CIPSA_CSharp_Module11.CakeShop.Models
{
    public class Cupcakes : CakeCommon
    {
        public string Name { get; set; }

        public Cupcakes(decimal price, FlavorEnum flavor, string name)
        {
            Price = price;
            Flavor = flavor;
            Name = name;
        }
        public override string ToString()
        {
            return $"Característica del producto: {GetProductName()}" +
                   $"\n Nombre personalizado: {Name} " +
                   "\n" + base.ToString();
        }

        private string GetProductName()
        {
            return "Magdalena";
        }
    }
}
