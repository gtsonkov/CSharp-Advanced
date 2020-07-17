using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Football_Team_Generator
{
    class StratUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string[] input = Console.ReadLine()
                .Split(";")
                .ToArray();
            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Team":
                        try
                        {
                            if (input.Length > 1)
                            {
                                Team CurrTeam = new Team(input[1]);
                                teams.Add(CurrTeam);
                            }
                            else
                            {
                                Console.WriteLine("A name should not be empty.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Add":
                        string teamName = input[1];
                        string playerName = input[2];
                        var currTeam = teams.FirstOrDefault(x => x.Name == teamName);
                        if (currTeam == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                        }

                        int en = int.Parse(input[3]);
                        int sp = int.Parse(input[4]);
                        int dr = int.Parse(input[5]);
                        int ps = int.Parse(input[6]);
                        int sh = int.Parse(input[7]);

                        try
                        {
                            Player currPlayer = new Player(playerName, en, sp, dr, ps, sh);

                            currTeam.AddPlayer(currPlayer);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Remove":
                        string _teamName = input[1];
                        string _playerName = input[2];
                        var _currTeam = teams.FirstOrDefault(x => x.Name == _teamName);
                        try
                        {
                            _currTeam.RemovePlayer(_playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Rating":
                        var teamname = input[1];
                        var team = teams.FirstOrDefault(x => x.Name == teamname);
                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamname} does not exist.");
                            break;
                        }

                        Console.WriteLine(team.Name + " - " + team.Rating());
                        break;

                    case "END":
                        return;


                }
                input = Console.ReadLine()
                .Split(";")
                .ToArray();
            }

            
        }
    }
}