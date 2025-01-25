using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvEngine
{
    internal interface IVehicalBase
    {
        int Weight { get; set; }
        int Length { get; set; }
        int PassangerSeats { get; set; }
    }
}
