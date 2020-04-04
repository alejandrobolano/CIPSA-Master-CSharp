using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Triangle : GeometricShape
    {
        public override decimal CalculatePerimeter()
        {
            return A * B * C;
        }

        public override decimal CalculateArea()
        {
            return A * (Radius / 2);
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
