using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson4
{
    /*
    Задание №5.
    Выполнил: Юдин Д.

    *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
    Реализовать конструктор, заполняющий массив случайными числами. 
    Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
    свойство, возвращающее минимальный элемент массива, 
    свойство, возвращающее максимальный элемент массива, 
    метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
    **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    **в) Обработать возможные исключительные ситуации при работе с файлами.
    */
    class DoubleArray
    {
        int[,] a2;

        /// <summary>
        /// Generate array with lines and columnts set, filled by random numbers from min to max
        /// </summary>
        /// <param name="n">  size of array</param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        public DoubleArray(int lines, int columns, int min, int max)
        {
            a2 = new int[lines,columns];
            Random r = new Random();
            
            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    a2[i, j] = r.Next(min, max);
                }
            }
        }

        /// <summary>
        /// Generate new Array from file with set numbers of columns
        /// </summary>
        /// <param name="link"></param>
        /// <param name="columns"></param>
        public DoubleArray(string link, int columns)
        {
            //a2 = new int[1, columns];
            try
            {
                StreamReader sr = new StreamReader(link);

                int linesConunt = TotalLines(link);
                a2 = new int[linesConunt/columns + linesConunt % columns, columns];

                int i = 0;
                int j = 0;

                while (!sr.EndOfStream)
                {

                    a2[i, j] = int.Parse(sr.ReadLine());

                    if (j != 0 && j == columns - 1)
                    {
                        j = 0;
                        i++;
                    }
                    else 
                    {
                        j++;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int this[int i,int k]
        {
            get
            {
                int n = a2[0, 0];

                return n;
            }
        }

        /// <summary>
        /// Length of the array
        /// </summary>
        public int length 
        {
            get 
            {
                return this.a2.Length;
            }
        }

        /// <summary>
        /// Min number in array
        /// </summary>
        public int min
        {
            get
            {
                int min = this[0, 0];

                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        if (a2[i, j] < min)
                        {
                            min = a2[i, j];
                        }
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Max number in array
        /// </summary>
        public int max
        {
            get
            {
                int max = this[0, 0];

                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        if (a2[i, j] > max)
                        {
                            max = a2[i, j];
                        }
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Print array (class) as string
        /// </summary>
        public override string ToString()
        {
            string array = "";

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    array += a2[i, j] + " ";
                }
                array += "\n";
            }
            return array;
        }

        /// <summary>
        /// Calculate the sum of all members of 2D Array
        /// </summary>
        /// <returns>int sum</returns>
        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    sum += a2[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Calculate the number of lines in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу ...");

            Console.WriteLine("Сейчас мы сгенериуем массив:");
            DoubleArray a2 = new DoubleArray(3, 4, 1, 20);
            Console.WriteLine(a2);
            Console.WriteLine($"Минимальное число: {a2.min}");
            Console.WriteLine($"Максимальное число: {a2.max}");

            int sum = a2.Sum();
            Console.WriteLine($"Сумма всех его членов: {sum}");

            Console.WriteLine("А теперь мы сгенериуем массив из файла:");
            DoubleArray a2_fromFile = new DoubleArray("..\\..\\2d_array.txt", 4);

            if (a2_fromFile.length != 0)
            {
                Console.WriteLine(a2_fromFile);
            }

            Console.ReadLine();
        }
    }
}
