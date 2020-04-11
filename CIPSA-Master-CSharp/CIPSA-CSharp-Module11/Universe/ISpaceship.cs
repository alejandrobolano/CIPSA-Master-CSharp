using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.Universe
{
    public interface ISpaceship
    {
        int AxisX { get; set; }
        int AxisY { get; set; }
        int Health { get; set; }

        int Shoot();
        void MoveToPosition(int axisX, int axisY);

       
    }
}
