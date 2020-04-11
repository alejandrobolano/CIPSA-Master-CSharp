using System;
using System.Windows.Shapes;
using System.Windows.Media;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Circle : GeometricShape
    {
        public double Radius { get; set; }
        public override double CalculatePerimeter()
        {
            var result = 2 * Math.PI * Radius;
            return Math.Round(result,2);
        }

        public override double CalculateArea()
        {
            var result = Math.PI * Math.Pow(Radius, 2);
            return Math.Round(result,2);
        }

        public override object Draw()
        {
            var circle = new Ellipse
            {
                Height = Radius,
                Width = Radius,
                Stroke = Brushes.Black,
                Fill = Brushes.Aqua
            };


            return circle;
        }
    }
}
