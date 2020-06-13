using System.IO;
using System.IO.Compression;

namespace _06_Zip_And_Extract
{
    class ZipAndExtract
    {
        static void Main(string[] args)
        {
            string pathFileToZip = Path.Combine("Data");
            string pathToSave = "../../myZip.zip";
            string pathToUnzip = "../../../ myZip.zip";
            ZipFile.CreateFromDirectory(pathFileToZip, pathToSave);
            ZipFile.ExtractToDirectory(pathToSave,pathToUnzip);
        }
    }
}