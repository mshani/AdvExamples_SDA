using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvShape
{
    internal class Rectangle : ShapeBase
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public override double CalculatePerimeter()
        {
            double p = 2 * Base +  2 * Height;
            return p;
        }

        public override double CalculateSurface()
        {
            double s = Base * Height;
            return s;
        }
    }
}
