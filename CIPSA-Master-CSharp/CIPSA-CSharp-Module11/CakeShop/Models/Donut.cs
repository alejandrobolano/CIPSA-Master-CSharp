using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.CakeShop.Enums;

namespace CIPSA_CSharp_Module11.CakeShop.Models
{
    public class Donut : CakeCommon
    {
        public bool HasHole { get; set; }

        public Donut(decimal price, FlavorEnum flavor, bool hasHole)
        {
            Price = price;
            Flavor = flavor;
            HasHole = hasHole;
        }

        public override string ToString()
        {
            var infoHole = HasHole ? "Hay que hacerle un agujero" : "No hay que hacerle agujero";
            return $"Característica del producto: {GetProductName()}" +
                   $"\n {infoHole} " +
                   "\n" + base.ToString();
        }

        private string GetProductName()
        {
            return "Donut";
        }
    }
}
