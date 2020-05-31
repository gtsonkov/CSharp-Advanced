using System;
using System.Collections.Generic;

namespace _01_Unique_Usernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var un in usernames)
            {
                Console.WriteLine(un);
            }
        }
    }
}