using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Geometrics
{
    public abstract class GeometricShape
    {
        public decimal Radius { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int Side { get; set; }

        public abstract decimal CalculatePerimeter();
        public abstract decimal CalculateArea();
        public abstract void Draw();
    }
}
