using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task6 {
    class EngDict : Translator {

        enum Language {
            Unknown = 0,
            Russian = 1,
            English = 2
        }

        Dictionary<string, HashSet<string>> _engWords, _ruWords;

        public EngDict() {
            _engWords = new Dictionary<string, HashSet<string>>
            {
                { "bye", new HashSet<string> { "пока" } }
            };

            _ruWords = new Dictionary<string, HashSet<string>>
            {
                { "привет", new HashSet<string> { "hello", "hi", "hey"} },
                { "пока", new HashSet<string> { "bye" } }
            };
        }


        public List<string> GetTranslations(string word) {
            List<string> translations = new List<string>();
            HashSet<string> words;
            if (_engWords.TryGetValue(word.ToLower(), out words)) {
                translations = words.ToList();
            }
            if (_ruWords.TryGetValue(word.ToLower(), out words)) {
                translations = words.ToList();
            }

            // Распечатка перевода
            if (translations.Count > 0) {
                for (int i = 0; i < translations.Count; i++) {
                    Console.WriteLine(translations[i]);
                }
            } else {
                Console.WriteLine("Данное слово в словаре не найдено.");
            }

            return translations;
        }

        public void Add(string word, List<string> translationsWords) {
            Language lang = Language.Unknown;
            CheckLanguage(word, ref lang);
            if (lang == Language.Unknown) return;
            Dictionary<string, HashSet<string>> currentDict = (lang == Language.English) ? _engWords : _ruWords;
                 
            HashSet<string> translations;
            foreach (var translation in translationsWords) {
                if (currentDict.TryGetValue(word.ToLower(), out translations)) {
                    translations.Add(translation.ToLower());
                } else {
                    translations = new HashSet<string>();
                    translations.Add(translation.ToLower());
                    currentDict.Add(word.ToLower(), translations);
                }
                Console.WriteLine($"{word} => {translation}");
            }
            return;
        }

        public void Add(string word, string translation) {
            Add(word, new List<string>() { translation });
        }

        private void CheckLanguage(string word, ref Language lang) {
            if (Regex.IsMatch(word, @"\b[а-я]+\b")) {
                lang = Language.Russian;
            }
            if (Regex.IsMatch(word, @"\b[a-z]+\b")) {
                lang = Language.English;
            }
        }

    }
}
