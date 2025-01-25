using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvEngine
{
    internal class Toyota : IEngine
    {
        public int Power { get; set; }
        public int RPM { get; set ; }
        public int Cylinders { get; set; }
        public int StartingSpeed(int gear)
        {
            if (gear <= 0)
            {
                return 0;
            }
            else if (gear == 1)
            {
                return 10;
            }
            else if (gear == 2)
            {
                return 20;
            }
            else if (gear == 3)
            {
                return 40;
            }
            else if (gear == 4)
            {
                return 50;
            }
            else if (gear == 5)
            {
                return 60;
            }
            else
            {
                return 70;
            }
        }
    }
}
