using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvShape
{
    internal class Cicle : ShapeBase
    {
        public double Radius { get; set; }
        public override double CalculatePerimeter()
        {
            double p = 2 * Radius * Math.PI;
            return p;
        }

        public override double CalculateSurface()
        {
            double s = Math.PI * Math.Pow(Radius, 2);
            return s;
        }
    }
}
