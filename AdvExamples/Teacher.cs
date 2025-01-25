using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvExamples
{
    internal class Teacher : Person
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public void Explain()
        {
            Console.WriteLine("I am explaining");
        }
    }
}
