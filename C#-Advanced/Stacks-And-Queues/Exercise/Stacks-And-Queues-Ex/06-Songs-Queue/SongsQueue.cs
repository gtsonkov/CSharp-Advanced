using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Songs_Queue
{
    class SongsQueue
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ").ToArray();
            Queue<string> songs = new Queue<string>(songsInput);

            while (songs.Count>0)
            {
                string token = Console.ReadLine();

                if (token.Contains("Play"))
                {
                    songs.Dequeue();
                }

                else if (token.Contains("Add"))
                {
                    string songName = token.Substring(4);
                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                }
                else if (token.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}