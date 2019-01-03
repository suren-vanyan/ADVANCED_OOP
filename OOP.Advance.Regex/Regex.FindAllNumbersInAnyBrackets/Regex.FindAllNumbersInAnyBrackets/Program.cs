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
            string test = @"(+10.77)qaz<10.32>wsx(0.5)dj[-99.2]sj.a'<6.7>{11.6}sjzx,\,[-4.5]<68.4> ";
            FindAllFlPointInAnyBrackets(test);

        }

        static void FindAllFlPointInAnyBrackets(string input)
        {
            //different syntax but group in the same way
            //string matchedSubexpressions = @"(\([+-]?\d+[.]\d+\))|(\[[+-]?\d+[.]\d+])|(\<[+-]?\d+[.]\d+\>)|(\{[+-]?\d+[.]\d+\})";
            string namematchedSubexpressions = @"(?<brOne>\[[+-]?\d+[.]\d+])|(?<brTwo>\([-+]?\d+[.]\d+\))|(?<brThree>\<[+-]?\d+[.]\d+\>)|(?<brFour>\{[+-]?\d+[.]\d+\})";
            //string namematchedSubexpressions2 = @"(?'br1'\[[+-]?\d+[.]\d+])|(?'br2'\([+-]?\d+[.]\d+\))|(?'br3'\<[+-]?\d+[.]\d+\>)|(?'br4'\{[+-]?\d+[.]\d+\})";
            var collection = Regex.Matches(input, namematchedSubexpressions);

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