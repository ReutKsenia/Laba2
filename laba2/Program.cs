using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            //...................1.....................
            //___________________a)____________________
            sbyte sby = 1;
            short sh = 35;
            int i32 = 88;
            long l = 1234;
            byte by = 15;
            ushort ush = 68;
            uint ui = 2345;
            ulong ul = 1_234_567;
            char ch = 's';
            bool bl = true;
            float f = 3.14F;
            double d = 1.22222D;
            decimal dec = 100_000_000_000;

            //________________b)___________________ 
            //1.Неявные приведения
            l = i32;
            d = f;
            ush = by;
            sh = sby;
            ul = ui;
            //2.Явные приведения
            i32 = (int)ch;  // избыточно
            ch = (char)by;  // неизбыточно
            d = (double)f;
            dec = (decimal)f;
            ui = (uint)ul;

            //_____________________c)___________________ 
            Object obj;
            obj = dec;          // упаковка
            dec = (decimal)obj; // распаковка

            //_____________________d)___________________
            var noName = 95; // тип получается из присваемого значения, у нас это int

            //_____________________e)___________________
            int? xNull = null;     // может хранить как значения, так и null
            noName = xNull ?? 12; // присвоит значение, если оно имеется, иначе присвоит второй операнд => 12

            //.....................2....................
            //_____________________a)__________________
            String str1 = "String1", str2 = "string1";
            if (str1 == str2)
            {
                Console.WriteLine("Строка \"{0}\" идентична строке \"{1}\"", str1, str2);
            }
            else
            {
                Console.WriteLine("Строка \"{0}\" не идентична строке \"{1}\"", str1, str2);
            }
            Console.WriteLine();

            //_____________________b)_____________________
            String str3 = "Собаки", str4 = "тоже", str5 = "люди!";
            String strConcat = str3 + ", " + str4 + " "  + str5; // конкатенация
            Console.WriteLine(strConcat);

            String str5Copy = String.Copy(str5);    // копирование
            Console.WriteLine(str5Copy);

            String str5Sub = str5Copy.Substring(4); //выделение подстроки
            Console.WriteLine(str5Sub);
           
            String[] words = strConcat.Split(' ');  // разделение на слова   
            foreach (String k in words)
            {
                Console.WriteLine(k);
            }

            String subString1 = strConcat.Insert(strConcat.Length, " хоть и маленькие");  // вставка подстроки в заданную позицию
            Console.WriteLine(subString1);

            String subString2 = subString1.Remove(strConcat.Length, 7);   // удаление заданной подстроки
            Console.WriteLine(subString2);
            Console.WriteLine();

            //________________________c)______________________
            String empStr = "", nullStr = null;
            if (empStr.CompareTo(nullStr) == 0) // для пустой строки можно вызывать методы,они будут идентичны
            {
                Console.WriteLine("Строка \"{0}\" идентична строке \"{1}\"", empStr, nullStr);
            }
            else
            {
                Console.WriteLine("Строка \"{0}\" идентична строке \"{1}\"", empStr, nullStr);
            }
            try
            {
                if (nullStr.CompareTo(empStr) == 0) // для null-строки нельзя вызывать методы, поэтому будет вызвано исключение
                {
                    Console.WriteLine("Строка \"{0}\" идентична строке \"{1}\"", empStr, nullStr);
                }
                else
                {
                    Console.WriteLine("Строка \"{0}\" идентична строке \"{1}\"", empStr, nullStr);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Вызвано исключение: " + e.Message);
            }
            Console.WriteLine();

            //___________________d)__________________
            StringBuilder strB = new StringBuilder("Просто текст", 42);
            strB.Remove(0, 7);
            Console.WriteLine(strB);
            strB.Insert(0, "Этот ");
            strB.Append(" очень информативный.");
            Console.WriteLine(strB);
            Console.WriteLine();

            //.................3.....................
            //________________a)_____________________
            int[,] arrayTwo = { { 2, 4, 6 }, { 8, 0, 2 }, { 4, 6, 8 } };
            for (int i = 0; i < arrayTwo.GetLength(0); i++)
            {
                for (int j = 0; j < arrayTwo.GetLength(1); j++)
                {
                    Console.Write("{0} ", arrayTwo[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //_________________b)____________________
            String[] arrayStr = new string[4] { "Это", "массив", "строк", "!" };
            foreach (String s in arrayStr)
            {
                Console.Write("{0} ", s);
            }
            Console.WriteLine("Длина массива строк:{0}", arrayStr.Length);
            Console.WriteLine("Введите номер элемента массива, который хотите изменить (Этот-0, массив-1 и т.д.):");
            String t = Console.ReadLine();
            int ins = Convert.ToInt32(t);
            Console.WriteLine("Введите значение, которым хотите заменить элемент массива:");
            String newStr= Console.ReadLine();
            arrayStr[ins] = newStr;
            foreach (String s in arrayStr)
            {
                Console.Write("{0} ", s);
            }
            Console.WriteLine(" ");
            Console.WriteLine();

            //_____________________c)____________________
            float[][] jaggedArr = { new float[2], new float[3], new float[4] };
            Console.WriteLine("Введите элементы массива:");
            try
            {
                for (int i = 0; i < jaggedArr.GetLength(0); i++)
                {
                    Console.WriteLine("Введите {0} элемента(ов) в {1} массив:", jaggedArr[i].Length, i + 1);
                    String enterString = Console.ReadLine();
                    string[] arrString = enterString.Split(new Char[] { ' ' });
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] = float.Parse(arrString[j]);
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < jaggedArr.GetLength(0); i++)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        Console.Write("{0} ", jaggedArr[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Вызвано исключение: " + e.Message);
            }
            Console.WriteLine();

            //_______________________d)_____________________
            var arr = new int[24];
            var str = "Попугайчик";

            //.......................4.....................
            //_______________________a)____________________
            (int iTup, String strTup, char chTup, String strTup1, ulong ulTup) tuple1 = (88, "Строка", 'c', "Очередная строка", 1234);
            Console.WriteLine();

            //_______________________c)____________________
            Console.WriteLine(tuple1);
            Console.WriteLine("{0}, {1}, {2}", tuple1.strTup, tuple1.strTup1, tuple1.ulTup.ToString());
            Console.WriteLine();


            //_______________________d)____________________
            (var one, var two, var three, var fourth, var fifth) = tuple1;
            Console.WriteLine(one);
            Console.WriteLine();

            //_______________________e)____________________
            (int intT, String strT, char charT, String strT1, ulong ulT) tuple2 = (88, "О боже", 'c', "Опять строка", 124);
            if (tuple1.CompareTo(tuple2) == 0)
            {
                Console.WriteLine("Кортеж {0} идентичен картежу {1}", tuple1, tuple2);
            }
            else
            {
                Console.WriteLine("Кортеж {0} не идентичен картежу {1}", tuple1, tuple2);
            }
            Console.WriteLine();

            //.....................5.........................
            (int max, int min, int sum, char firstLet) LocFun(int[] array, String strLoc)
            {
                int sum = 0;
                foreach (int i in array)
                {
                    sum += i;
                }
                Array.Sort(array);
                return (array[array.Length - 1], array[0], sum, strLoc.ToCharArray()[0]);
            }
            int[] intArr = { 21, 0, 8, 3, 16, 1 };
            String s1 = "BlaBlaBla";
            Console.WriteLine(LocFun(intArr, s1));


        }
    }
}
