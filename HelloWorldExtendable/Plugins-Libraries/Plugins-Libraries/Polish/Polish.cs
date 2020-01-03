using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;

namespace Polish
{
    [Language("Polish")]
    public class Polish : TranslatorBase
    {
        public override string Translate()
        {
            return "Witaj świecie";
        }
    }
}
