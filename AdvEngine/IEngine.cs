using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvEngine
{
    internal interface IEngine
    {
        int Power { get; set; }
        int RPM { get; set; }
        int Cylinders { get; set; }
        int StartingSpeed(int gear);
    }
}
