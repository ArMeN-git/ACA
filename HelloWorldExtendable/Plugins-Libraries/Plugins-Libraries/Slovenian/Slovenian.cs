using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;

namespace Slovenian
{
    [Language("Slovenian")]
    public class Slovenian : TranslatorBase
    {
        public override string Translate()
        {
            return "Pozdravljen, svet";
        }
    }
}
