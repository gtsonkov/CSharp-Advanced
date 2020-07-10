using System;

namespace StackOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StackString myStack = new StackString();

            myStack.Push("A");
            myStack.Push("B");
            myStack.Push("C");

            myStack.AddRange(new string[] { "C", "D", "E" });

            while (!myStack.IsEmpty())
            {
                Console.WriteLine(myStack.Pop());
            }

        }
    }
}