using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public abstract class GeometricShape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public abstract object Draw();
    }
}
