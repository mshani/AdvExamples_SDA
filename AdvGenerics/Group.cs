using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvGenerics
{
    internal class Group<T>
    {
        public int Count { get; set; }
        public List<T> Elements { get; set; } = new List<T>();
    }
}
