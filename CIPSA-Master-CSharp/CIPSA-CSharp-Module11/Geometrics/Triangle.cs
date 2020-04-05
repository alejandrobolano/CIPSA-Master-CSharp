using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Triangle : GeometricShape
    {
        public decimal SideA { get; set; }
        public decimal SideB { get; set; }
        public decimal SideC { get; set; }
        public decimal HighBaseA { get; set; }
        public override decimal CalculatePerimeter()
        {
            var result = SideA + SideB + SideC;
            return decimal.Round(result, 2);
        }

        public override decimal CalculateArea()
        {
            var result = SideA * (HighBaseA / 2);
            return decimal.Round(result, 2);
        }

        public override string Draw()
        {
            return base.Draw() + "El triángulo";
        }
    }
}
