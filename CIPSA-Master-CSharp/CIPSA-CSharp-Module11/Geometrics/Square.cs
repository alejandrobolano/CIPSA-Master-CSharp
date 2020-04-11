using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Square : GeometricShape
    {
        public double Side { get; set; }
        public override double CalculatePerimeter()
        {
            var result = 2 * Side;
            return Math.Round(result,2);
        }

        public override double CalculateArea()
        {
            var result = Math.Pow(Side, 2);
            return Math.Round(result, 2);
        }

        public override object Draw()
        {
            var rectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Aqua,
                Width = Side,
                Height = Side
            };

           return rectangle;
        }
    }
}
