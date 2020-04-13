using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.CakeShop.Enums;
using CIPSA_CSharp_Module11.Extensions;

namespace CIPSA_CSharp_Module11.CakeShop.Models
{
    public class CakeCommon
    {
        public decimal Price { get; set; }
        public FlavorEnum Flavor { get; set; }

        public override string ToString()
        {
            return $" Sabor del producto: {Flavor.GetDescription()}" +
                   $"\n Precio: {Price}€";
        }
    }
}
