using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  SELECT - tanlangan qiymatlarning proektsiyasini belgilaydi

            string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
                            "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

            //bu yerda select cars masivvining har bir elementini uzunligi qaytaradi
            IEnumerable<int> sequence = cars.Select(p => p.Length);

            Console.WriteLine("Select results:");
            foreach (int i in sequence)
                Console.Write(i + " ");

            Console.WriteLine();
            #endregion

            #region Where - tanlov filtrini belgilaydi
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            //where yordamida 10 dan katta va juft degan shart bilan elementlar saralab olinadi
            IEnumerable<int> evens = numbers.Where(i => i % 2 == 0 && i > 10);

            Console.WriteLine("\nWhere results:");
            foreach (var evs in evens)
                Console.Write(evs + "  ");

            Console.WriteLine();
            #endregion

            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            #region OrderBy va OrderByDescending - elementlarni o'sish - kamayish taribida saralaydi

            // StudentName bo'yicha o'sish tartibida saralanadi
            var orderByResult = from s in studentList
                                orderby s.StudentName
                                select s;

            // Age bo'yicha kamayish tartibida saralanadi
            var orderByDescendingResult = from s in studentList
                                          orderby s.Age descending
                                          select s;

            Console.WriteLine("\nOrderBy result:");
            foreach (var student in orderByResult)
                Console.WriteLine(student.StudentName);

            Console.WriteLine("\nOrderByDescending result:");
            foreach (var ages in orderByDescendingResult)
                Console.WriteLine(ages.Age);

            Console.WriteLine();
            #endregion

            #region ThenBy Va ThenByDescending - kengaytirish usullari bir vaqtda bir necha maydonlarni saralash uchun ishlatiladi.

            //StudentName va Age bo'yicha o'sish tartibida saralash
            var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);

            //StudentName bo'yicha o'sish va Age bo'yicha kamayish tartibida saralash
            var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.Age);

            Console.WriteLine("OrderBy vs ThenByDescending result:");
            foreach (var st in orderByDescendingResult)
                Console.WriteLine(st.StudentName + '\t' + st.Age);

            Console.WriteLine();
            #endregion

            #region Join - to'plamlarni birlashtiradi
            IList<string> strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four",
                "Five"
            };

            IList<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six",
                "Seven"
            };

            //to'plamlarning har birida mavjud bo'lgan elementlarni qaytaradi | to'plamlar kesishmasi
            var innerJoin = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);
            Console.WriteLine("Join result:");
            foreach (var i in innerJoin)
                Console.WriteLine(i);

            Console.WriteLine();
            #endregion

            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 },
                new Student() { StudentID = 6, StudentName = "Tom" , Age = 20 } ,
                new Student() { StudentID = 7, StudentName = "Nick" , Age = 18 }
            };

            #region Group va ToLookUp - ko'rsatilgan maydon bo'yicha guruhlaydi

            // studentList2 yosh bo'yicha guruhlarga ajratiladi
            var groupedResult = from s in studentList2
                                group s by s.Age;

            Console.WriteLine("Group result:");
            foreach (var ageGroup in groupedResult)
            {
                //har bir guruh uchun iteratsiya jarayoni 
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //har bir guruhda Key mavjud

                foreach (var s in ageGroup) // har bir guruhda inner to'plami mavjud
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
            Console.WriteLine('\n');
            //ToLookUp group bilan bir xil vazifa bajaradi
            var lookupResult = studentList2.ToLookup(s => s.Age);

            Console.WriteLine("ToLookUp result:");
            foreach (var group in lookupResult)
            {
                Console.WriteLine("Age Group: {0}", group.Key);

                foreach (Student s in group)
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }

            Console.WriteLine("\n");
            #endregion

            #region GroupJoin - to'plamlarni umumiy xususiyati boyicha guruhlaydi
            IList<Human> people = new List<Human>() {
                new Human() { HumanID = 1, HumanName = "John", StandardID =1 },
                new Human() { HumanID = 2, HumanName = "Moin", StandardID =1 },
                new Human() { HumanID = 3, HumanName = "Bill", StandardID =2 },
                new Human() { HumanID = 4, HumanName = "Ram",  StandardID =2 },
                new Human() { HumanID = 5, HumanName = "Ron" , StandardID =3}
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            //ikkala to'plamda mavjuda bo'lgan StandardID xususiyati bo'yicha people ni guruhlaydi
            var groupJoin = standardList.GroupJoin(people,  //inner sequence
                                            std => std.StandardID, //outerKeySelector 
                                            s => s.StandardID,     //innerKeySelector
                                            (std, humans_group) => new // resultSelector 
                                            {
                                                Humans = humans_group,
                                                HumansFulldName = std.StandardName
                                            });

            Console.WriteLine("GroupJoin result:");
            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.HumansFulldName);

                foreach (var stud in item.Humans)
                    Console.WriteLine(stud.HumanName);
            }
            Console.WriteLine();
            #endregion

            #region Reverse - to'plamni oyog'ini osmondan qilib teskari tartiblaydi
            int[] intArray = new int[] { 310, 10, 501, 430, 60, 20, 70, 100 };

            var ArrayReversedData = intArray.Reverse();

            Console.WriteLine("Reverse result:");
            foreach (var number in ArrayReversedData)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");
            #endregion

            #region All vs Any vs Contains - to'plam elementlari orasida berilgan shartni tekshiradi

            // students to'plamdagi barcha studentlar yoshlari 12-21 oralig'idagini tekshiradi
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 26);

            Console.WriteLine("All result:");
            Console.WriteLine(areAllStudentsTeenAger);

            // students to'plamdagi studentlar ichida yoshi 20 dan kattasi mavjudligini tekshiradi
            bool isAnyStudentTeenAger = studentList.Any(s => s.Age > 20);
            Console.WriteLine("Any result:");
            Console.WriteLine(areAllStudentsTeenAger);

            // cars to'plamida Jaguar elementi mavjudligini tekshiradi
            bool contains = cars.Contains("Jaguar");
            Console.WriteLine("Наличие \"Jaguar\" в массиве: " + contains);

            Console.WriteLine("\n");
            #endregion

            #region Sum - to'plamdagi to'plamdagi raqamli elementlarning yig'indisini hisoblab chiqadi
            List<int> natural_sonlar = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var Jami_yigindi = natural_sonlar.Sum();

            Console.WriteLine($"To'plam elementlari yig'indisi: {Jami_yigindi}");

            var Toq_yigindi = natural_sonlar.Sum(i => {
                if (i % 2 == 1)
                    return i;

                return 0;
            });

            Console.WriteLine($"To'plamdagi toq sonlar yig'indisi: {Toq_yigindi}");

            var Juft_yigindi = natural_sonlar.Sum(i => {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            Console.WriteLine($"To'plamdagi juft sonlar yig'indisi: {Juft_yigindi}");
            #endregion

            #region Average - to'plamdagi to'plamdagi raqamli elementlarning yig'indisini hisoblab chiqadi
            IList<Hodimlar> HodimlarList = new List<Hodimlar>() {
                new Hodimlar() { HodimID = 1,Hodim_Ismi = "John", Hodim_Yoshi = 13 } ,
                new Hodimlar() { HodimID = 2,Hodim_Ismi = "Moin", Hodim_Yoshi = 21 } ,
                new Hodimlar() { HodimID = 3,Hodim_Ismi = "Bill", Hodim_Yoshi = 18 } ,
                new Hodimlar() { HodimID = 4,Hodim_Ismi = "Ram", Hodim_Yoshi = 20 } ,
                new Hodimlar() { HodimID = 5,Hodim_Ismi = "Ron", Hodim_Yoshi = 15 }
              };

            var ortacha_yosh = HodimlarList.Average(s => s.Hodim_Yoshi);

            Console.WriteLine($"Hodimlarning o'rtacha yoshi: {ortacha_yosh}");
            #endregion
            #region Davomi bor
            //DAVOMI KEYINGI SONLARDA... :)
            #endregion
        }
    }
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public byte Age { get; set; }
    }

    public class Human
    {
        public int HumanID { get; set; }
        public string HumanName { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    class Hodimlar
    {
        public int HodimID { get; set; }
        public string Hodim_Ismi { get; set; }
        public int Hodim_Yoshi { get; set; }
    }
}
