using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Universe
{
    public class XWing : ISpaceship
    {
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public int Health { get; set; }

        public XWing()
        {
            AxisX = 0;
            AxisY = 0;
            Health = 100;
        }
        public int Shoot()
        {
            //Health = -2;
            return 10;
        }

        public void MoveToPosition(int axisX, int axisY)
        {
            AxisX = axisX;
            AxisY = axisY;
        }

        public override string ToString()
        {
            return "XWing";
        }

    }
}
