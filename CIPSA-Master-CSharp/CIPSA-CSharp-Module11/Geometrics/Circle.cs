using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Circle : GeometricShape
    {
        public override decimal CalculatePerimeter()
        {
            return 2 * Convert.ToDecimal(Math.PI) * Radius;
        }

        public override decimal CalculateArea()
        {
            return Convert.ToDecimal(Math.PI * Math.Pow(Convert.ToDouble(Radius), 2));
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
