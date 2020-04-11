using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Universe
{
    public class TieFighter : ISpaceship
    {
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public int Health { get; set; }

        public TieFighter()
        {
            AxisX = 0;
            AxisY = 0;
            Health = 100;
        }
        public int Shoot()
        {
            //Health = -1;
            return 5;
        }

        public void MoveToPosition(int axisX, int axisY)
        {
            AxisX = axisX * 2;
            AxisY = axisY * 2;
        }

        public override string ToString()
        {
            return "TieFighter";
        }
    }
}
