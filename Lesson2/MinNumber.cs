using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    Написать метод, возвращающий минимальное из трёх чисел.
    Улучшено, можно ввести сколько угодно чисел.
    */
    class MinNumber
    {

        static int min;
        
        static void minNumber(List<int> numbers) 
        {
            min = numbers[0];

            foreach (int n in numbers) 
            {
                if (n < min) 
                {
                    min = n;
                }
            }
        }
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по расчету минимального числа");
            List<int> numbers = new List<int>();

            Console.WriteLine("Укажите сколько чисел вы хотите ввести:");
            int q = int.Parse(Console.ReadLine());

            for (int i = 1; i <= q; i++) 
            {
                Console.WriteLine($"Введите {i}-ое число");
                int n = int.Parse(Console.ReadLine());
                numbers.Add(n);
            }

            minNumber(numbers);
            Console.WriteLine($"Минимальное число: {min}");
            Console.ReadLine();
        }
    }
}
