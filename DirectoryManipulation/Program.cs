using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryManipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            string rootDir = @"D:\Test\DIRManipulator";
            

            //if (Directory.Exists(rootDir))
            //{
            //    Directory.Delete(rootDir);
            //}

            DirectoryInfo dirInfo = new DirectoryInfo(rootDir);

            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }

            Directory.CreateDirectory(rootDir);

            

            string file1Path = Path.Combine(rootDir, "file1.txt");
            string file2Path = Path.Combine(rootDir, "file2.txt");

            string[] filesToCreate = new string[] { file1Path, file2Path };

            // Stworzyć dwa pliki

            foreach (var file in filesToCreate)
            {
                File.Create(file).Dispose();
            }

            // Stworzyc dwa foldery


            string[] foldersToCreate = new string[]
            {
                Path.Combine(rootDir, "backup1"),
                Path.Combine(rootDir, "backup2"),
                Path.Combine(rootDir, "backup3", "backup4")
             };

            foreach (var folder in foldersToCreate)
            {
                Directory.CreateDirectory(folder);
            }

            Console.WriteLine("Actual folders");

            foreach (var item in dirInfo.EnumerateDirectories())
            {
                Console.WriteLine(dirInfo.FullName);
            }

            Console.ReadKey();
        }
    }
}
