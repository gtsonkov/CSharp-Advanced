namespace SantaWorkshop.IO
{
    using System;
    using System.IO;
    using SantaWorkshop.IO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            using StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(message);
        }
    }
}
