using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace OOPAdvanceRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"{((<qazwsx>[0-9a-z]))(\.(?!\.))(abcde)<123[0-9a-z]test{hi}>([-!#\$%&'])}"; 
            Console.WriteLine(CheckCorrectBracket(input));
        }

        static bool CheckGroupValueBYCount(string input)
        {
            //here I divided into two groups
            string patternOne = @"(?<bracket>[({<\[])";
            string patternTwo = @"(?<bracket2>[)}>\]])";
            var regexOne = new Regex(patternOne);
            var regexTwo = new Regex(patternTwo);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Match item in regexOne.Matches(input))
            {
                Console.WriteLine($"RegexOne: Index{item.Index},Value{item.Value}");
            }

            
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Match item in regexTwo.Matches(input))
            {
                Console.WriteLine($"RegexOne: Index{item.Index},Value{item.Value}");
            }

            Console.ResetColor();
            //here I check the number of elements are equal or not
            var groupOneCount = (from Match one in regexOne.Matches(input)
                                 select one.Value).Count();

            var groupTwoCount = (from Match two in regexTwo.Matches(input)
                                 select two.Value).Count();

            if (groupOneCount != groupTwoCount)
                return false;
            return true;
        }

        static bool CheckCorrectBracket(string input)
        {
            //   at the CheckGroupValueBYCount Method I divided into two groups
            //and check if the groups are not equal return false results
            if (CheckGroupValueBYCount(input))
            {
                string patternOne = @"(?<bracket>[(){}<>\[\]])";
                var regex = new Regex(patternOne);
                string temp = string.Empty;

                foreach (Match item in regex.Matches(input))
                {
                    temp += item;
                }

                //IEnumerable<string> result = (from Match m in regex.Matches(input)
                //              let n = m.Value
                //              where n.Contains("()")||n.Contains("<>")||
                //              n.Contains("{}")||n.Contains("[]")
                //              select n.Replace("()","").Replace("{}","")
                //              .Replace("[]","").Replace("<>",""));

                while (temp.Contains("()")||temp.Contains("[]")||temp.Contains("<>")||temp.Contains("{}"))
                {
                    temp = temp.Replace("()", "");
                    temp = temp.Replace("[]", "");
                    temp = temp.Replace("<>", "");
                    temp = temp.Replace("{}", "");

                }

                if (temp == string.Empty)
                    return true;
                else
                    return false;
               
                                            
            }
            else
                return false;


        }
    }
}

