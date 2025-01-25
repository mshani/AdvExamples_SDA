using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLanguages
{
    internal class AlbanianLanguage : LanguageBase
    {
        public override void SayBye()
        {
            Console.WriteLine("Mirupafshim");
        }

        public override void SayHi()
        {
            Console.WriteLine("Pershendetje");
        }
    }
}
