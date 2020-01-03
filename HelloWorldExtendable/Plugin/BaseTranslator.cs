using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public abstract class TranslatorBase
    {
        public abstract string Translate();
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class LanguageAttribute : Attribute
    {
        public string Language { get; }
        public LanguageAttribute() { }
        public LanguageAttribute(string language) => this.Language = language;
    }
}
