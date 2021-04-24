using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task6
{
    class EngDict: Translator
    {
        Dictionary<string, HashSet<string>> _engWords, _ruWords;

        public EngDict()
        {
            _engWords = new Dictionary<string, HashSet<string>>
            {
                { "hello", new HashSet<string> { "привет", "здравствуй"} },
                { "bye", new HashSet<string> { "пока" } }
            };

            _ruWords = new Dictionary<string, HashSet<string>>
            {
                { "привет", new HashSet<string> { "hello", "hi", "hey"} },
                { "пока", new HashSet<string> { "bye" } }
            };
        }


        public List<string> GetTranslations(string word)
        {
            List<string> translations = new List<string>();
            HashSet<string> words;
            if (_engWords.TryGetValue(word.ToLower(), out words))
            {
                translations = words.ToList();
            }

            // Распечатка перевода
            if (translations.Count > 0)
            {
                for (int i = 0; i < translations.Count; i++)
                {
                    Console.WriteLine(translations[i]);
                }
            } else
            {
                Console.WriteLine("Данное слово в словаре не найдено.");
            }

            return translations;
        }

        public void Add(string word, string translation)
        {
            HashSet<string> translations;
            if (_engWords.TryGetValue(word.ToLower(), out translations)) {
                translations.Add(translation.ToLower());
            } else
            {
                translations = new HashSet<string>();
                translations.Add(translation.ToLower());
                _engWords.Add(word.ToLower(), translations);
            }
            Console.WriteLine($"Добавлен перевод \"{translation.ToLower()}\" к слову \"{word.ToLower()}\"");
            return;
        }

        public void Add(string word, List<string> translations)
        {
            return;
        }
      
    }
}
