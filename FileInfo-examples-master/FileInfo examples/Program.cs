using System;
using System.IO;

namespace FileInfo_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //faylga yo'l
            string path = @"C:\Users\user\Desktop\test.txt";

            //FileInfo sinfidan yangi obyekt hosil qilish
            FileInfo fileInfo = new FileInfo(path);

            #region FileInfo xususiyatlari
            //Exist yordamida fayl mavjudligini tekshirish
            if (fileInfo.Exists)
            {
                //fayl xususiyatlarini chiqarish
                Console.WriteLine($"Fayl joylashgan katalog: \t{fileInfo.Directory}");
                Console.WriteLine($"Faylning to'liq yo'li: \t{fileInfo.DirectoryName}");

                Console.WriteLine($"Fayl mavjudligi: \t{fileInfo.Exists}");
                Console.WriteLine($"Fayl kengaytmasi: \t{fileInfo.Extension}");

                Console.WriteLine($"Fayl nomi: \t{fileInfo.Name}");
                Console.WriteLine($"Faylning to'liq nomi: \t{fileInfo.FullName}");

                Console.WriteLine($"Yaratilgan vaqti: \t{fileInfo.CreationTime}");
                Console.WriteLine($"Hajmi: \t{fileInfo.Length} bayt");

                Console.WriteLine($"Oxirgi marta o'zgartirilgan vaqti: \t{fileInfo.LastWriteTime}");
                Console.WriteLine($"Oxirgi marta foydalanilgan vaqti: \t{fileInfo.LastAccessTime}");

                Console.WriteLine($"Faqat o'qiladigan faylligi: \t{fileInfo.IsReadOnly}");
                Console.WriteLine($"Fayl atributi: \t{fileInfo.Attributes}");
            }
            #endregion

            #region FileInfo metodlari
            string copyfile = @"C:\Users\user\Desktop\test - copy.txt";

            //fayldan nusxa ko'chirish
            if (fileInfo.Exists)
                fileInfo.CopyTo(copyfile, true);

            //faylni ko'chirish
            string newPath = @"D:\documents\test.txt";
            //if (!fileInfo.Exists)
            //    fileInfo.MoveTo(newPath);

            //faylni o'chirish
            //FileInfo fileInfo1 = new FileInfo(copyfile);
            //if(fileInfo1.Exists)
            //    fileInfo1.Delete();

            //AppendText metodi yordamida faylga matn qo'shish
            FileInfo f = new FileInfo(@"D:\Test.txt");
            StreamWriter sw = f.AppendText();

            sw.WriteLine("1-satr");
            sw.WriteLine("2 - satr");
            sw.WriteLine("SATR 3");
            sw.Close();

            string s;
            //OpenText metodi yordamida faylni ochish
            Console.WriteLine("\nO'zgartirilgan fayl:");
            StreamReader sr = f.OpenText();
            s = sr.ReadLine();
            Console.WriteLine(s);
            s = sr.ReadLine();
            Console.WriteLine(s);
            s = sr.ReadLine();
            Console.WriteLine(s);
            s = sr.ReadLine();
            Console.WriteLine(s);
            sr.Close();
            #endregion
            Console.ReadKey();
        }
    }
}
