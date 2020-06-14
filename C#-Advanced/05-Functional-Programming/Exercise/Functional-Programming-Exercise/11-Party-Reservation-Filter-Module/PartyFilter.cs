using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Party_Reservation_Filter_Module
{
    class PartyFilter
    {
        private static Func<string, bool> ApllyFilter(string filterType, string condition)
        {
            switch (filterType)
            {
                case "Starts with":
                    return (x => x.StartsWith(condition));

                case "Ends with":
                    return (x => x.EndsWith(condition));

                case "Lenght":
                    return (x => x.Length == int.Parse(condition));

                case "Contains":
                    return (x => x.Contains(condition));

                default: return null;
            }
        }

        static void Main(string[] args)
        {
            List<string> peopleList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                      .ToArray();

            List<string> commands = new List<string>();

            while (command[0] != "Print")
            {
                if (command[0].Contains("Add"))
                {
                    commands.Add($"{command[1]}, {command[2]}");
                }
                else
                {
                    commands.Remove($"{command[1]}, {command[2]}");
                }

                command = Console.ReadLine()
                      .Split(";", StringSplitOptions.RemoveEmptyEntries)
                      .ToArray();
            }
            var filteredData = new List<string>();
            
            foreach (var cm in commands)
            {
                string commandType = cm.Split(", ").ToArray()[0];
                string token = cm.Split(", ").ToArray()[1];
                var currFilter = ApllyFilter(commandType, token);

                peopleList = peopleList.Where((p => !currFilter(p))).ToList();
            }

            Console.WriteLine(string.Join(" ", peopleList));
        }
    }
}