using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Lecture2
    {

        public static void RunTasks()
        {
            FirstTask2("Hello there :)", 5);
            ThirdTask2();
        }

        private static void FirstTask2(string input, int charIndex)
        {
            Console.WriteLine($"Input: [{input}]; [{charIndex}] letter is: [{input[charIndex]}]; Total length: [{input.Length}]");
        }

        private static void ThirdTask2()
        {
            string badString = "  A_v-eRy_*LonG_*sTr*INg     thAt_*Sho*-u-LD_-*Be_S*pl-It   ";
            Console.WriteLine($"badString: [{badString}]");

            string stringWithoutSymbols = badString.Replace("-", "").Replace("*", "");
            Console.WriteLine($"stringWithoutSymbols: [{stringWithoutSymbols}]");

            string lowerString = stringWithoutSymbols.ToLower();
            Console.WriteLine($"lowerString: [{lowerString}]");

            string firstPartOfString = lowerString.Substring(0, lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine($"firstPartOfString: [{firstPartOfString}]");

            string secondPartOfString =
                lowerString.Substring(lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase),
                    lowerString.Length - lowerString.IndexOf("that", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine($"secondPartOfString: [{secondPartOfString}]");

            string firstPartOfTrimmedString = firstPartOfString.Trim().Replace("_", " ");
            Console.WriteLine($"firstPartOfTrimmedString: [{firstPartOfTrimmedString}]");
            string secondPartOfTrimmedString = secondPartOfString.Trim().Replace("_", " ");
            Console.WriteLine($"secondPartOfTrimmedString: [{secondPartOfTrimmedString}]");

            string wholeString = $"{firstPartOfTrimmedString} {secondPartOfTrimmedString}";
            Console.WriteLine($"wholeString: [{wholeString}]");
        }
    }
}
