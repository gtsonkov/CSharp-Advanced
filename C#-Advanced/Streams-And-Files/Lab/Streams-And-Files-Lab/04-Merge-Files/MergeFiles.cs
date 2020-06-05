using System;
using System.IO;

namespace _04_Merge_Files
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            string fileToRead1 = Path.Combine("Data", "input1.txt");
            string fileToRead2 = Path.Combine("Data", "input2.txt");
            string[] files = { fileToRead1, fileToRead2 };

            string fileToWrite = Path.Combine("Data", "output.txt");

            using (var output = new FileStream(fileToWrite, FileMode.Create))
            {
                for (int i = 0; i < 2; i++)
                {
                    using (var input = new FileStream(files[i], FileMode.Open))
                    {
                        long size = input.Length;

                        int partSize = (int)Math.Ceiling((double)size / 4096);

                        for (int j = 0; j < partSize; j++)
                        {
                            byte[] buffer = new byte[4096];

                            int readedBytes = input.Read(buffer, 0, 4096);

                            output.Write(buffer, 0, readedBytes);
                        }
                    }
                }
            }
        }
    }
}