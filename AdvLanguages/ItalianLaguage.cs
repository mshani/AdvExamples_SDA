using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvLanguages
{
    internal class ItalianLaguage : LanguageBase
    {
        public override void SayBye()
        {
            Console.WriteLine("Arrivederci");
        }

        public override void SayHi()
        {
            Console.WriteLine("Ciao");
        }
    }
}
