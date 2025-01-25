using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvEngine
{
    internal class MercedesBenz : IEngine, IVehicalBase
    {
        public int Power { get; set; }
        public int RPM { get; set ; }
        public int Cylinders { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int PassangerSeats { get; set; }
        public int StartingSpeed(int gear)
        {
            if (gear <= 0) { 
                return 0;
            }
            else if (gear == 1)
            {
                return 10;
            }
            else if (gear == 2) 
            {
                return 40;
            }
            else if (gear == 3)
            {
                return 60;
            }
            else if (gear == 4)
            {
                return 80;
            }
            else if (gear == 5)
            {
                return 100;
            }
            else
            {
                return 120;
            }
        }
    }
}
