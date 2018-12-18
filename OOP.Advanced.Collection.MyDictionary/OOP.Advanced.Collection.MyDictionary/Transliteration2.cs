﻿using System.Collections.Generic;
using System.Text;

namespace OOP.Advanced.Collection.MyDictionary
{
    static partial class Transliteration
    {
        private static Dictionary<string, string> _mydict = new Dictionary<string, string>();     

        private static string EnglishToArmenian(string text)
        {
            AddKeyAndValue(_mydict);
           
            string temp = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                temp += _mydict[text[i].ToString()];
            }

            text = Orthography(text);
            return temp;

        }

        private static string ArmenianToEnglish(string text)
        {
            AddKeyAndValue(_mydict);
            text = Orthography(text);
            string temp = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                temp += _mydict[text[i].ToString()];
            }
            return text;
        }


        static string Orthography(string text) //ուղղագրություն
        {
            text = text.Replace("սh", "շ");
            text = text.Replace("սh", "շ");
            text = text.Replace("jh", "ժ");
            text = text.Replace("ch", "չ");
            text = text.Replace("gh", "ղ");
            text = text.Replace("ev", "և");
            text = text.Replace("dz", "ձ");
            text = text.Replace("vo", "ո");
            text = text.Replace("ph", "փ");
            text = text.Replace("ts", "ծ");
            return text;
        }


        private static void AddKeyAndValue(Dictionary<string, string> mydictionary)
        {

            mydictionary.Add("a", "ա");
            mydictionary.Add("b", "բ");
            mydictionary.Add("c", "ց");
            mydictionary.Add("d", "դ");
            mydictionary.Add("e", "ե");
            mydictionary.Add("f", "ֆ");
            mydictionary.Add("g", "գ");
            mydictionary.Add("h", "հ");
            mydictionary.Add("i", "ի");
            mydictionary.Add("j", "ջ");
            mydictionary.Add("k", "կ");
            mydictionary.Add("l", "լ");
            mydictionary.Add("m", "մ");
            mydictionary.Add("n", "ն");
            mydictionary.Add("o", "ո");
            mydictionary.Add("p", "պ");
            mydictionary.Add("q", "ք");
            mydictionary.Add("r", "ր");
            mydictionary.Add("s", "ս");
            mydictionary.Add("t", "տ");
            mydictionary.Add("u", "ու");
            mydictionary.Add("v", "վ");
            mydictionary.Add("w", "ո");
            mydictionary.Add("x", "խ");
            mydictionary.Add("y", "յ");
            mydictionary.Add("z", "զ");
            mydictionary.Add("@", "ը");
            mydictionary.Add("&", "ճ");
        
        }

        public static string Translit(string str)
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
            string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (int i = 0; i <= 32; i++)
            {
                str = str.Replace(rus_up[i], lat_up[i]);
                str = str.Replace(rus_low[i], lat_low[i]);
            }
            return str;
        }
    }
}