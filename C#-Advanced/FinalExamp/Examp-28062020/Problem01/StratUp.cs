using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    class StratUp
    {
        static void Main(string[] args)
        {
            int[] inputBombEffects = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] inputBombCasings = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int> bombTypes = new Dictionary<string, int>();
            bombTypes.Add("Datura Bombs", 40);
            bombTypes.Add("Cherry Bombs", 60);
            bombTypes.Add("Smoke Decoy Bombs", 120);

            Dictionary<string, int> createdBombs = new Dictionary<string, int>();
            createdBombs.Add("Cherry Bombs", 0);
            createdBombs.Add("Datura Bombs", 0);
            createdBombs.Add("Smoke Decoy Bombs", 0);

            bool bombPouchFilledSuccessfull = false;

            Queue<int> bombEffects = new Queue<int>(inputBombEffects);
            Stack<int> bombCasings = new Stack<int>(inputBombCasings);

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int currSum = bombEffects.Peek() + bombCasings.Peek();

                if (bombTypes.ContainsValue(currSum))
                {
                    string currBomb = bombTypes.FirstOrDefault(x => x.Value == currSum).Key;

                    createdBombs[currBomb]++;

                    bombEffects.Dequeue();
                    bombCasings.Pop();

                    bool bombPouchFilled = true;

                    foreach (var bomb in createdBombs)
                    {
                        if (bomb.Value < 3)
                        {
                            bombPouchFilled = false;
                            break;
                        }
                    }

                    if (bombPouchFilled)
                    {
                        Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                        bombPouchFilledSuccessfull = true;
                        break;
                    }
                }
                else
                {
                    int currCasingValue = bombCasings.Pop() - 5;

                    bombCasings.Push(currCasingValue);
                }
            }

            if (!bombPouchFilledSuccessfull)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ",bombEffects));
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasings));
            }

            foreach (var b in createdBombs)
            {
                Console.WriteLine($"{b.Key}: {b.Value}");
            }
        }
    }
}