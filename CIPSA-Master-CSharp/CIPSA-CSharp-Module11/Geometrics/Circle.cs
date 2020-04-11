using System;
using System.Windows.Shapes;

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

        public override object Draw()
        {
            var circle = new Ellipse
            {
                Height = (double) Radius,
                Width = (double) Radius,
                Stroke = System.Windows.Media.Brushes.Black,
                Fill = System.Windows.Media.Brushes.Aqua
            };


            return circle;
        }
    }
}
