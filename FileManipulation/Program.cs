using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo(@"D:\Test");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            FileInfo fi = new FileInfo(@"D:\Test\test.txt");

            // Tworzenie pliku

            using (FileStream fs = File.Create(@"D:\Test\test.txt")) ;
            {

            }          
            
            //Dodawanie tekstu do pliku

            File.AppendAllText(fi.FullName,"Hello");

            // Kopiowanie pliku

            File.Copy(fi.FullName, @"D:\Test\test_copy.txt");

            
            //Dodawanie tekstu do pliku

            File.AppendAllText(@"D:\Test\test_copy.txt", "\n Hello_copy");
        }
    }
}
