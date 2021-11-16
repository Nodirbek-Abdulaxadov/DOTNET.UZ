using System;
using System.IO;
using System.Linq;

namespace File_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is first line." + Environment.NewLine +
                    "This is second line." + Environment.NewLine +
                    "This is third line.";

            //TextFile.txt ni ochadi va text ni qo'shadi. Agar TextFile.txt mavjud bo'lmasa avval yaratadi, ochadi va text ni qo'shadi
            File.AppendAllLines(@"C:\TextFile.txt", text.Split(Environment.NewLine.ToCharArray()).ToList<string>());

            //yuqoridagi metodga o'xshash lekin bunda text qo'shiladi (qatorlar emas)
            File.AppendAllText(@"C:\ TextFile.txt", "This is File testing");

            //TextFile.txt ni ochadi va yozadi. Agar TextFile.txt mavjud bo'lmasa avval yaratadi, ochadi va yozadi
            File.WriteAllText(@"C:\TextFile.txt", "This is some text");

            //ko'rsatilgan fayl mavjudligini tekshiradi
            bool isFileExists = File.Exists(@"C:\ TextFile.txt"); // returns false

            //TextFile.txt ni yangi NewFileNew.txt sifatida nusxalaydi
            File.Copy(@"C:\TextFile.txt", @"D:\NewTextFile.txt");

            //Fayl oxirgi marta ishlatilgan vaqtini aniqlaydi
            DateTime lastAccessTime = File.GetLastAccessTime(@"C:\TextFile.txt");

            //Fayl oxirgi marta o'zgartirilgan vaqtini aniqlaydi
            DateTime lastWriteTime = File.GetLastWriteTime(@"C:\TextFile.txt");

            //Faylni yangi joyga ko'chiradi
            File.Move(@"C:\TextFile.txt", @"D:\TextFile.txt");

            //Faylni ochadi va fayldan bayt o'qish uchun FileStream hosil qiladi
            FileStream fs = File.Open(@"D:\TextFile.txt", FileMode.OpenOrCreate);

            //Faylni ochadi va fayldan bayt o'qish uchun StreamReader hosil qiladi
            StreamReader sr = File.OpenText(@"D:\TextFile.txt");

            //Faylni o'chiradi
            File.Delete(@"C:\TextFile.txt");
        }
    }
}
