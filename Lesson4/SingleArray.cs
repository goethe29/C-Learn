using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ArrayClassLibrary; // My Personal Library

namespace Lesson4
{
    /*
    Задание №3.
    Выполнил: Юдин Д.

    а) Дописать класс для работы с одномерным массивом. 
    -Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
    -Создать свойство Sum, которое возвращает сумму элементов массива, 
    -метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
    -метод Multi, умножающий каждый элемент массива на определённое число, 
    -свойство MaxCount, возвращающее количество максимальных элементов. 
                КАКОЙ СМЫСЛ? У нас массив возрастающий: от указанного числа до маскимального с заданным шагом
    б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
    в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
    */
    class SingleArray
    {
        int[] a;
        int length;
        int Sum;
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        //int maxCount;

        /// <summary>
        /// Generate array where n = size of array, first = 2st number, step = step for number incrementation 
        /// </summary>
        /// <param name="n">  size of array</param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        public SingleArray(int n, int first, int step)
        {
            a = new int[n];
            int next = first;

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = next;
                next += step;
                Sum += a[i];

                try
                {
                    frequency.Add(next, 1);
                }
                catch (ArgumentException)
                {
                    frequency[next] = frequency[next] + 1;
                }
            }
            this.length = a.Length;
            //maxCount = 1; 
            // Always = 1. BECAUSE WE HAVE ASCENDING ARRAY! EVERY NEXT NUMBER IS GREATER THAN PREVIOUS ONE. 
            // PLEASE KILL AUTHOR OF METODICHKA/Manual!

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
        /// Return new array with all numbers from initial array with inversed sign
        /// </summary>
        /// <returns></returns>
        public SingleArray Inverse() 
        {
            SingleArray b = new SingleArray(this.length,0,0);

            for (int i = 0; i < this.length; i++)
            {
                b[i] = a[i] * -1;
            }

            return b; 
        }

        /// <summary>
        /// Mulitiply every member of array by n
        /// </summary>
        /// <param name="n"></param>
        public void Multi(int n)
        {
            for (int i = 0; i < this.length; i++)
            {
                a[i] *= n;
            }
        }

        static public void start()
        {
            SingleArray array = new SingleArray(5, 2, 2);
            Console.WriteLine($"Добро пожаловать в программу. Дан массив: {array}");
            Console.WriteLine($"Сумма: {array.Sum}");

            SingleArray inversed = array.Inverse();
            Console.WriteLine($"\nИнверсивный массив: {inversed}");
            Console.WriteLine($"Первый массив без изменений: {array}");

            array.Multi(2);
            Console.WriteLine($"Теперь умножим каждый член массива на 2: {array}");

            MyArray array3 = new MyArray(10, 2, 2);
            Console.WriteLine($"\nМассив из библиотеки: {array3}");


            SingleArray array4 = new SingleArray(5, 1, 0);
            Console.WriteLine($"\nВозьмем еще один массив массив: {array4}");
            Console.WriteLine($"Частотное вхождение:");

            foreach (KeyValuePair<int, int> kvp in array4.frequency)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }



            Console.ReadLine();
        }
    }
}