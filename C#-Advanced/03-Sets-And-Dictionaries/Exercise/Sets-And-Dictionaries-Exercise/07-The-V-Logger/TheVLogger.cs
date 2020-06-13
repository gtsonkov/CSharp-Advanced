using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_The_V_Logger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<List<string>>> vLoggerList = new Dictionary<string, List<List<string>>>();
            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Statistics")
            {
                string userName = input[0]; 
                string command = input[1];
                if (command == "joined")
                {
                    if (!(vLoggerList.ContainsKey(userName)))
                    {
                        List<List<string>> info = new List<List<string>>(2);
                        List<string> followers = new List<string>();
                        List<string> following = new List<string>();
                        info.Add(followers);
                        info.Add(following);

                        vLoggerList.Add(userName,info);
                    }
                }
                else if (command == "followed")
                {
                    string followedUser = input[2];

                    if (vLoggerList.ContainsKey(userName) && vLoggerList.ContainsKey(followedUser) && userName != followedUser)
                    {
                        if (!vLoggerList[userName][1].Contains(followedUser))
                        {
                            vLoggerList[userName][1].Add(followedUser);
                            vLoggerList[followedUser][0].Add(userName);
                        }
                    }
                }

                input = Console.ReadLine().Split().ToArray();
            }

            var orderedvLoggerList = vLoggerList.OrderByDescending(x => x.Value[0].Count()).ThenBy(x=> x.Value[1].Count);

            Console.WriteLine($"The V-Logger has a total of {orderedvLoggerList.Count()} vloggers in its logs.");
            int count = 1;
            var firsVlogger = orderedvLoggerList.First();

            Print(count, firsVlogger.Key, firsVlogger.Value[0].Count, firsVlogger.Value[1].Count);

            foreach (var v in firsVlogger.Value[0].OrderBy(x=>x))
            {
                Console.WriteLine($"*  {v}");
            }

            foreach (var v in orderedvLoggerList)
            {
                if (count == 1)
                {
                    count++;
                }
                else
                {
                    Print(count, v.Key, v.Value[0].Count, v.Value[1].Count);
                    count++;
                }
            }
        }

        private static void Print(int count, string name, int followers, int following)
        {
            Console.WriteLine($"{count}. {name} : {followers} followers, {following} following");
        }
    }
}