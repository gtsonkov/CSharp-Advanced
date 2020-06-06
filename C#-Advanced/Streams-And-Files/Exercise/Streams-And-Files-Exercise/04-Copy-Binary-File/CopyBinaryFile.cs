using System;
using System.IO;

namespace _04_Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string sorcePath = Path.Combine("Data", "copyMe.png");
            string destPath = Path.Combine("Data", "logo.png");

            using (var sr = new FileStream(sorcePath,FileMode.Open))
            {
                byte[] buffer = new byte[4096];

                using (var sw = new FileStream(destPath,FileMode.Create))
                {
                    int bytesReaded = sr.Read(buffer, 0, 4096);

                    while (buffer.Length > 0)
                    {
                        sw.Write(buffer,0,bytesReaded);

                        if (bytesReaded < 4096)
                        {
                            break;
                        }

                        if (sr.CanRead)
                        {
                            bytesReaded = sr.Read(buffer, 0, 4096);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}