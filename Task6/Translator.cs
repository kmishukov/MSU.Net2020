using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    interface Translator
    {
        void Add(string word, string translation);
        void Add(string word, List<string> translations);
        List<string> GetTranslations(string word);
    }
}
