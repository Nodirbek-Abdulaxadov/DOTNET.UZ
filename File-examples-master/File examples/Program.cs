using System;
using System.IO;

namespace File_examples
{
    class Program
    {        
        static void Main(string[] args)
        {   
            // string text yozish
            string writeText = "Hello World!";

            string writelines = "This is first line." + Environment.NewLine +
                    "This is second line." + Environment.NewLine +
                    "This is third line.";

            // fayl yaratish va unga text yozish
            File.WriteAllText("filename.txt", writeText+'\n'+writelines);  

            // fayldagi textni o'qish
            string readText = File.ReadAllText("filename.txt");

            // natijani ekranga chiqarish
            Console.WriteLine(readText);

            Console.ReadKey();
        }
    }
}
