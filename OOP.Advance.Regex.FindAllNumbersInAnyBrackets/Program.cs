using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOP.Advance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find a List of floating point numbers, which occur in any type of brackets.
            string test = "(10.77)qazwsx(0.5)djsj.a'<6.7>{11.6}sjjjd[4.5]<68.4> ";
            FindAllFlPointInAnyBrackets(test);

        }

        static void FindAllFlPointInAnyBrackets(string input)
        {

            string pattern = @"(?<brOne>\(\d+[.]\d+\))|(?<brTwo>\[\d+[.]\d+\])
                                |(?<brThree>\<\d+[.]\d+\>)|(?<brFour>\{\d+[.]\d+\})";
            var collection = Regex.Matches(input, pattern);
           
            foreach (Match group in collection)
            {              
                Console.ForegroundColor = (ConsoleColor)(new Random().Next(1, 15));
                var newMatchCollection = Regex.Matches(group.Value, @"(\d+[.]\d+)");
                foreach (var item in newMatchCollection)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}