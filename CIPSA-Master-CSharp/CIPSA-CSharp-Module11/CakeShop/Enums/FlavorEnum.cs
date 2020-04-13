using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.CakeShop.Enums
{
    public enum FlavorEnum
    {
        [Description("Chocolate")]
        Chocolate,
        [Description("Fresa")]
        Strawberry,
        [Description("Mermelada de Melocotón")]
        PeachJam,
        [Description("Mermelada de Naranja")]
        OrangeJam,
        [Description("Chocolate blanco")]
        WhiteChocolate,
        [Description("Miel y nueces")]
        NutAndHoney,
        [Description("Dulce de leche")]
        Caramel,
        [Description("Crema")]
        Cream

    }
}
