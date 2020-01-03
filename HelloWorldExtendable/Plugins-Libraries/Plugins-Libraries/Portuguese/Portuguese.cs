using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;

namespace Portuguese
{
    [Language("Portuguese")]
    public class Portuguese : TranslatorBase
    {
        public override string Translate()
        {
            return "Olá Mundo";
        }
    }
}
