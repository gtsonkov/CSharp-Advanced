using System;
using System.IO;

namespace _05_File_Slice
{
    class FileSlice
    {
        static void Main(string[] args)
        {
            string textPath = Path.Combine("Data", "input.txt");

            using (var input = new FileStream(textPath,FileMode.Open))
            {
                long size = input.Length;

                long partSize = (long)Math.Ceiling((double)size/4);

                for (int i = 1; i <= 4; i++)
                {
                    byte[] buffer = new byte[partSize];

                    using (var output = new FileStream($"Data\\Part{i}.txt",FileMode.Create))
                    {
                        int bytesReaded = input.Read(buffer, 0, (int)partSize);

                        output.Write(buffer,0, bytesReaded);
                    }
                }
            }
        }
    }
}