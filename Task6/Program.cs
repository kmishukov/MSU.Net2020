using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator translator = new EngDict();
            translator.Add("hello", "приветики");

            List<string> hello = translator.GetTranslations("hello");
        }
    }
}
