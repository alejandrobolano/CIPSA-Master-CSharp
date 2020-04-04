using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Square : GeometricShape
    {
        public override decimal CalculatePerimeter()
        {
            return 2 * Side;
        }

        public override decimal CalculateArea()
        {
            return Convert.ToDecimal(Math.Pow(Side, 2));
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
