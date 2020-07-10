using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child newChild = new Child(name, age);

            Console.WriteLine(newChild);
        }
    }
}