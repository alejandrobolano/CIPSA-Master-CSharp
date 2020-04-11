using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Square : GeometricShape
    {
        public decimal Side { get; set; }
        public override decimal CalculatePerimeter()
        {
            var result = 2 * Side;
            return decimal.Round(result,2);
        }

        public override decimal CalculateArea()
        {
            var result = Convert.ToDecimal(Math.Pow(Convert.ToDouble(Side), 2));
            return decimal.Round(result, 2);
        }

        public override object Draw()
        {
            throw new NotImplementedException();
        }
    }
}
