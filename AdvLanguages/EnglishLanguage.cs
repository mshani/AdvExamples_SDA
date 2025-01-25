using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLanguages
{
    internal class EnglishLanguage : LanguageBase
    {
        public override void SayBye()
        {
            Console.WriteLine("Bye");
        }

        public override void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }
}
