using System;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Наполнение словаря");
            Console.ForegroundColor = ConsoleColor.White;
            Translator translator = new EngDict();
            List<string> translations = new List<string>();
            translations.Add("привет");
            translations.Add("здравствуй");
            translator.Add("hello", translations);
            translator.Add("hello", "салют");
            translator.Add("игры", "games");
            translator.Add("игры", "toys");

            string word1 = "hello";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nПереводы слова \"{word1}\":");
            Console.ForegroundColor = ConsoleColor.White;
            List<string> hello = translator.GetTranslations(word1);
            string word2 = "игры";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nПереводы слова \"{word2}\":");
            Console.ForegroundColor = ConsoleColor.White;
            List<string> toys = translator.GetTranslations(word2);
        }
    }
}
