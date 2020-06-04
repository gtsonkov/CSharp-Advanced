using System;
using System.IO;

namespace _06_Folder_Size
{
    class FolderSize
    {
        static void Main(string[] args)
        {
            //string dataPath = Path.Combine("C:", "Microsoft");
            string dataPath = Path.Combine("SomeDir");

            var files = Directory.GetFiles(dataPath);

            double size = GetSize(dataPath);

            Console.WriteLine($"Directory size: {size} Bytes");
        }

        private static long GetSize(string path)
        {
            var directory = Directory.GetDirectories(path);

            if (directory.Length > 0)
            {
                long size = 0;

                foreach (var dir in directory)
                {

                    var files = Directory.GetFiles(dir);

                    var u_directory = Directory.GetDirectories(Path.GetFullPath(dir));

                    if (u_directory.Length>0)
                    {
                        size += GetSize(Path.GetFullPath(dir));

                        foreach (var file in files)
                        {
                            var info = new FileInfo(file);
                            size += info.Length;
                        }
                    }
                    else
                    {
                        foreach (var file in files)
                        {
                            var info = new FileInfo(file);
                            size += info.Length;
                        }
                    }
                }

                return size;
            }

            else
            {
                long size = 0;
            
                var files = Directory.GetFiles(path);
            
                foreach (var file in files)
                {
                    var info = new FileInfo(file);
                    size += info.Length;
                }
                
                return size;
            }
            
        }
    }
}