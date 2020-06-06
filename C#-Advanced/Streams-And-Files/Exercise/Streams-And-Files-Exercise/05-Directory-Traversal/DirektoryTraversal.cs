using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05_Directory_Traversal
{
    class DirektoryTraversal
    {
        static void Main(string[] args)
        {
            string searchedExtension = ".";
            string dirPath = Environment.CurrentDirectory;
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string writePath = Path.Combine(desktopFolder, "report.txt");

            StringBuilder sb = new StringBuilder();

            var files = Directory.GetFiles(dirPath, $"{searchedExtension}");

            Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();

            foreach (var f in files)
            {
                FileInfo info = new FileInfo(f);

                string extension = info.Extension;
                string fileName = info.Name;
                double size = (info.Length / 1024.00);

                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, double>());
                }

                data[extension].Add(fileName, size);
            }
                foreach (var ex in data
                    .OrderByDescending(x => x.Value.Count())
                    .ThenBy(x => x.Key))
                {
                    sb.AppendLine(ex.Key);

                    foreach (var file in ex.Value.OrderBy(x => x.Value))
                    {
                        sb.AppendLine($"--{file.Key}{ex.Key} - {file.Value:f3}kb");
                    }
                }
                
            
            File.WriteAllText(writePath, sb.ToString());
        }
    }
}