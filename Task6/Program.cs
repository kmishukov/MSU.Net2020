using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator translator = new EngDict();
            translator.Add("hello", "приветики");
            translator.Add("игры", "games");
            translator.Add("игры", "toys");

            List<string> hello = translator.GetTranslations("hello");
            List<string> toys = translator.GetTranslations("игры");
        }
    }
}
