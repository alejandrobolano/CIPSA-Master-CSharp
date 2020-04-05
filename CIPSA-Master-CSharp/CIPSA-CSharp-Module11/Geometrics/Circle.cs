using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Circle : GeometricShape
    {
        public decimal Radius { get; set; }
        public override decimal CalculatePerimeter()
        {
            var result = 2 * Convert.ToDecimal(Math.PI) * Radius;
            return decimal.Round(result,2);
        }

        public override decimal CalculateArea()
        {
            var result = Convert.ToDecimal(Math.PI * Math.Pow(Convert.ToDouble(Radius), 2));
            return decimal.Round(result,2);
        }

        public override string Draw()
        {
            return base.Draw() + "El círculo";
        }
    }
}
