using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Predicate_Party
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var listOfPeople = Console.ReadLine()
                .Split()
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (command[0] != "Party!")
            {
                string executeCommand = command[0];
                string action = command[1];
                string criterial = command[2];

                Func<string, bool> startWith = x => x.StartsWith(criterial);
                Func<string, bool> endWith = x => x.EndsWith(criterial);


                switch (executeCommand)
                {
                    case "Double":

                        var listOfFilteredPeople = new List<string>();
                        switch (action)
                        {
                            case "StartsWith":
                                listOfFilteredPeople = listOfPeople.Where(startWith).ToList();
                                break;

                            case "EndsWith":
                                listOfFilteredPeople = listOfPeople.Where(endWith).ToList();
                                break;

                            case "Length":
                                listOfFilteredPeople = listOfPeople.Where(x => x.Length == int.Parse(criterial)).ToList();
                                break;
                        }

                        listOfPeople.InsertRange(0,listOfFilteredPeople);
                        break;

                    case "Remove":
                        {
                            var listOfFilteredPeople2 = new List<string>();

                            switch (action)
                            {
                                case "StartsWith":

                                    listOfFilteredPeople2 = listOfPeople.Where(startWith).ToList();

                                    Action<List<string>> removePeopleStart = peoplecoll =>
                                    {
                                        for (int i = 0; i < listOfFilteredPeople2.Count; i++)
                                        {
                                            listOfPeople.Remove(listOfFilteredPeople2[i]);
                                        }
                                    };
                                    removePeopleStart(listOfFilteredPeople2);

                                    break;

                                case "EndsWith":
                                    listOfFilteredPeople2 = listOfPeople.Where(endWith).ToList();

                                    Action<List<string>> removePeopleEnd = peoplecoll =>
                                    {
                                        for (int i = 0; i < listOfFilteredPeople2.Count; i++)
                                        {
                                            listOfPeople.Remove(listOfFilteredPeople2[i]);
                                        }
                                    };

                                    removePeopleEnd(listOfFilteredPeople2);
                                    break;

                                case "Length":
                                    listOfFilteredPeople2 = listOfPeople.Where(x => x.Length == int.Parse(criterial)).ToList();

                                    Action<List<string>> removePeopleLenght = peoplecoll =>
                                    {
                                        for (int i = 0; i < listOfFilteredPeople2.Count; i++)
                                        {
                                            listOfPeople.Remove(listOfFilteredPeople2[i]);
                                        }
                                    };
                                    removePeopleLenght(listOfFilteredPeople2);
                                    break;
                            }
                        }
                        break;
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            if (listOfPeople.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", listOfPeople)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}