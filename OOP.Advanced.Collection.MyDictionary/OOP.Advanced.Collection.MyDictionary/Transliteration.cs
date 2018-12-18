using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Advanced.Collection.MyDictionary
{
    public static partial class Transliteration
    {
        public static string TranslateFromEnglishToLanguage(this string source, Language toLanguage)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            switch (toLanguage)
            {
                // my translator does not support Russian language yet
                case Language.Armenian:
                    return EnglishToArmenian(source);            
                case Language.Russain:
                   return EnglishToRussian(source);

            }

            throw new NotSupportedException();
        }

        public static string TranslateFromArmenianToEnglish(this string source, Language toLanguage)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            switch (toLanguage)
            {
                //   my translator does not support  translate from Armenian to Russian language yet
                //case Language.Russain:
                //    return ArmenianToRussian(source);
                case Language.English:
                    return ArmenianToEnglish(source);
                 

            }

            throw new NotSupportedException();
        }
    }
}
