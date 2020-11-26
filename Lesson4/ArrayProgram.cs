using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    /*
    Задание №1.
    Выполнил: Юдин Д.

    Дан  целочисленный  массив  из 20 элементов.  
    Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
    Заполнить случайными числами.  
    Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
    В данной задаче под парой подразумевается два подряд идущих элемента массива. 
    Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
    */
    class ArrayProgram
    {
        /// <summary>
        /// Methods that take int[] and returns qty of pairs where only 1 number is dividebale by 3
        /// </summary>
        static public int countPairs(int[] a) 
        {
            int count = 0;

            for (int i = 0; i < a.Length-1; i++)
            {
                if ((a[i] % 3 == 0 && a[i + 1] % 3 != 0) || (a[i] % 3 != 0 && a[i + 1] % 3 == 0))
                {
                    count++;
                }
            }
            return count;
        }
        
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу. Дан массив из 20 цифр:");

            int[] a = new int[20];

            Random r = new Random();

            for (int i = 0; i < a.Length; i++) 
            {
                a[i] = r.Next(-10000, 10000);
                Console.Write(a[i] + " ");
            }

            int pairs = countPairs(a);
            Console.WriteLine($"\nКоличество пар цифр, которые делятся на 3: {pairs}");

            Console.ReadLine();
        }
    }
}
