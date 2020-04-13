using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.CakeShop.Enums
{
    public enum SizeEnum
    {
        [Description("Grande")]
        Big,
        [Description("Medianos")]
        Medium,
        [Description("Pequeño")]
        Small
    }
}
