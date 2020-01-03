using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;

namespace Bulgarian
{
    [Language("Bulgarian")]
    class Bulgarian : TranslatorBase
    {
        public override string Translate()
        {
            return "Здравей свят";
        }
    }
}
