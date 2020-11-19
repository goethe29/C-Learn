using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
    б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
    */
    class RecursionExample
    {
        static string generateNumbersRow(int a, int b) 
        {
            if (a <= b) 
            {
                return a + " " + generateNumbersRow(++a, b);
            }
            return "";

        }

        static int generateNumbersSum(int a, int b)
        {
            if (a <= b)
            {
                return a + generateNumbersSum(++a, b);
            }
            return 0;

        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу вывода на экран чисел от a до b(a<b)");
            Console.WriteLine("Ниже выведены числа от 10 до 20");
            Console.WriteLine(generateNumbersRow(10, 20));
            Console.WriteLine($"Сумма чисел от 10 до 20: {generateNumbersSum(10,20)}");

            Console.ReadLine();
        }
    }
}
