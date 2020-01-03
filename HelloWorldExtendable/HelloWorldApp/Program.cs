using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Plugin;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            AppSettingsReader ar = new AppSettingsReader();
            string alllangs = (string)ar.GetValue("Plugins", typeof(string));
            string[] langs = alllangs.Split(',');
            if(!PrintAvailableTranslation(langs))
                Console.WriteLine("No translator found");
            Console.ReadKey();
        }

        private static bool PrintAvailableTranslation(string[] plugins)
        {
            bool is_translator = false;
            for(int i = 0; i < plugins.Length; i++)
            {
                Assembly asm = null;
                try
                {
                    asm = Assembly.LoadFrom($"../../../Plugins/{plugins[i]}.dll");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                var pluginTypes = from t in asm.GetTypes()
                                  where t.IsClass && (t.BaseType == typeof(TranslatorBase))
                                  select t;

                foreach (Type t in pluginTypes)
                {
                    is_translator = true;
                    TranslatorBase obj = (TranslatorBase)asm.CreateInstance(t.FullName, true);
                    Console.Write(obj?.Translate());

                    var lang_attr = t.GetCustomAttribute(typeof(LanguageAttribute)) as LanguageAttribute;
                    if(lang_attr == null)
                        Console.WriteLine(" (n/a)");
                    else
                        Console.WriteLine($" ({lang_attr.Language})");
                }
            }
            return is_translator;
        }
    }
}
