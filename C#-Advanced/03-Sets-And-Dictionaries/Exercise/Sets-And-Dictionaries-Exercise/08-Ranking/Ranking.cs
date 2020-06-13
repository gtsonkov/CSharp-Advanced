using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08_Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            string[] inputContests = Console.ReadLine().Split(":").ToArray();
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (inputContests[0] != "end of contests")
            {
                string contest = inputContests[0];
                string pass = inputContests[1];

                contests.Add(contest,pass);

                inputContests = Console.ReadLine().Split(":").ToArray();
            }

            string[] inputUsers = Console.ReadLine().Split("=>").ToArray();
            SortedDictionary<string, Dictionary<string, int>> usersInfo = new SortedDictionary<string, Dictionary<string, int>>();

            while (inputUsers[0] != "end of submissions")
            {
                string contest = inputUsers[0];
                string pass = inputUsers[1];
                string user = inputUsers[2];
                int scores = int.Parse(inputUsers[3]);

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (usersInfo.ContainsKey(user))
                    {
                        if (usersInfo[user].ContainsKey(contest))
                        {
                            if (usersInfo[user][contest] < scores)
                            {
                                usersInfo[user][contest] = scores;
                            }
                        }
                        else
                        {
                            usersInfo[user].Add(contest, scores);
                        }
                    }
                    else
                    {
                        Dictionary<string, int> currUserContests = new Dictionary<string, int>();
                        currUserContests.Add(contest,scores);
                        usersInfo.Add(user, currUserContests);
                    }
                }

                inputUsers = Console.ReadLine().Split("=>").ToArray();
            }

            var maxUser = usersInfo.OrderByDescending(x => x.Value.Sum(s => s.Value)).First();

            Console.WriteLine($"Best candidate is {maxUser.Key} with total {maxUser.Value.Sum(x => x.Value)} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in usersInfo)
            {
                var temp = user.Value.OrderByDescending(x => x.Value);
                Console.WriteLine(user.Key);
                foreach (var cont in temp)
                {
                    Console.WriteLine($"#  {cont.Key} -> {cont.Value}");
                }
            }
        }
    }
}