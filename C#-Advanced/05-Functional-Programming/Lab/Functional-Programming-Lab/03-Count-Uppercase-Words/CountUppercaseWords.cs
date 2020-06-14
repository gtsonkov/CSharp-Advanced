using System;
using System.Linq;

namespace _03_Count_Uppercase_Words
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            #region Variant 1

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(e => char.IsUpper(e[0]))
                .ToArray()));

            #endregion

            #region Variant 2

            //string[] inpit = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .ToArray();
            //
            //foreach (var item in inpit)
            //{
            //    if (char.IsUpper(item[0]))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region Variant 3
            //Predicate<string> UppercaseChecker = 
            //    str => char.IsUpper(str[0]);
            //Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Where(w => UppercaseChecker(w))
            //    .ToList()
            //    .ForEach(w => Console.WriteLine(w));
            #endregion
        }
    }
}