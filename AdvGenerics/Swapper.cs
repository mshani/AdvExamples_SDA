using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvGenerics
{
    internal class Swapper<T>
    {
        public T? Prop1 { get; set; }
        public T? Prop2 { get; set; }
        public void Swap()
        {
            T temp = Prop1;
            Prop1 = Prop2;
            Prop2 = temp;
        }
    }
}
