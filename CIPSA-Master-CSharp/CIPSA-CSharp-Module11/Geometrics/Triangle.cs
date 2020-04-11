using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public class Triangle : GeometricShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double HighBaseA { get; set; }
        public override double CalculatePerimeter()
        {
            var result = SideA + SideB + SideC;
            return Math.Round(result, 2);
        }

        public override double CalculateArea()
        {
            var semiPerimeter = (SideA + SideB + SideC) / 2; 
            var result = Math.Sqrt(
                CalculateAuxArea(semiPerimeter,SideA) *
                CalculateAuxArea(semiPerimeter,SideB) *
                CalculateAuxArea(semiPerimeter,SideC) );
            return Math.Round(result, 2);
        }

        private double CalculateAuxArea(double semiPerimeter, double valueVariable)
        {
            return semiPerimeter * Math.Abs(semiPerimeter - valueVariable);
        }

        public override object Draw()
        {
            var triangle = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Aqua,
            };

            var medianaABx = (SideA + SideB) / 2;
            var collection = new List<Point>()
            {
                new Point(1, SideA),
                new Point(SideB, 1),
                new Point(medianaABx, SideC)
            };
            var pointCollection = new PointCollection(collection);
            triangle.Points = pointCollection;
            
            return triangle;
        }
    }
}
