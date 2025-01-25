using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvExamples
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
        public string FullName
        {
            get
            {
                string fullname = $"{Name} {Surname}";
                return fullname ;
            }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now.Month == Birthday.Month)
                {
                    if (DateTime.Now.Day < Birthday.Day) {
                        age--;
                    }
                }
                else if (DateTime.Now.Month < Birthday.Month)
                {
                    age--;
                }
                return age;
            }
        }
        public void Greet()
        {
            Console.WriteLine($"Hi I'm {FullName}");
        }
    }
}