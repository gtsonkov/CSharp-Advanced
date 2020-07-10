using System;

namespace CustomRandomList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myRandomList = new RandomList(new string[] { "A", "B", "C", "D", "E", "F", "G", });

            Console.WriteLine(myRandomList.RandomString());
        }
    }
}