using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson4
{
    /*
    Задание №2.
    Выполнил: Юдин Д.

    Реализуйте задачу 1 в виде статического класса StaticClass;
    а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
    в)**Добавьте обработку ситуации отсутствия файла на диске.
    */
    class StaticArray
    {
        int[] a;
        int length;
        
        /// <summary>
        /// Generate array with n size, filled by random numbers from min to max
        /// </summary>
        /// <param name="n">  size of array</param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        public StaticArray(int n, int min, int max)   
        {
            a = new int[n];
            Random r = new Random();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(min, max);
            }
            this.length = a.Length;
        }

        /// <summary>
        /// Generate array from File where first line - size of array, other lines - parts of the array
        /// </summary>
        /// <param name="link">Link to the file like "..\\..\\data.txt"</param>
        /// <returns></returns>
        public static  int[] arrayFromFile(string link)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(link);
                int n = int.Parse(sr.ReadLine());
                int[] a = new int[n];

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = int.Parse(sr.ReadLine());
                }

                sr.Close();
                return a;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            return null;
        }

        /// <summary>
        /// Method to get/set values of array
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        /// <summary>
        /// Methods that take int[] and returns qty of pairs where only 1 number is dividebale by 3
        /// </summary>
        /// <param name="a">array of int</param>
        /// <returns></returns>
        static public int countPairs(int[] a)
        {
            int count = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if ((a[i] % 3 == 0 && a[i + 1] % 3 != 0) || (a[i] % 3 != 0 && a[i + 1] % 3 == 0))
                {
                    count++;
                }
            }
            return count;
        }
        
        /// <summary>
        /// Print array (class) as string
        /// </summary>
        public override string ToString() 
        {
            string array = "";

            for (int i = 0; i < a.Length; i++)
            {
                array += a[i] + " ";
            }
            return array;
        }

        /// <summary>
        /// Print regular array as string
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string print(int[] a)
        {
            string array = "";

            for (int i = 0; i < a.Length; i++)
            {
                array += a[i] + " ";
            }
            return array;
        }

        static public void start()
        {
            StaticArray array = new StaticArray(20, -10000, 10000);
            Console.WriteLine($"Добро пожаловать в программу. Дан массив: {array}");

            int pairs = countPairs(array.a);
            Console.WriteLine($"\nКоличество пар цифр, которые делятся на 3: {pairs}");

            int[] array2 = arrayFromFile("..\\..\\data.txt");

            if (array2 != null)
            {
                Console.WriteLine($"Сгенерирован массив из файла: {print(array2)}");
            }
            Console.ReadLine();
        }
    }
}
