using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Advanced.Collection.MyDictionary
{
    public static partial class Transliteration
    {
        public static string TranslateFromLanguageToLanguage(this string source, Language fromLanguage)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            switch (fromLanguage)
            {
                //   my translator does not support  translate from Armenian to Russian,and from Russian To English language yet
                case Language.English://From English to Armenian
                    return EnglishToArmenian(source);
                case Language.Russain:
                    return RussianToEnglish(source);
          
            }

            throw new NotSupportedException();
        }
       
    }
}
