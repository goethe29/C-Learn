using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
    Хорошим» называется число, которое делится на сумму своих цифр. 
    Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

    */
    class GoodNumbers
    {
        static int digitsSum(int n) 
        {
            int sum = 0;

            while (n != 0) 
            {
                sum += n % 10;
                n = n / 10;
            }
            return sum;
        }

        static bool isGoodNumber (int n) 
        {
            int s = digitsSum(n);
            return n % s == 0;
        }

        static int countGoodNumbers(int max) 
        {
            int goodNumbersCount = 0;

            for (int i = 1; i <= max; i++) 
            {
                if (isGoodNumber(i)) 
                {
                    goodNumbersCount += 1;
                    // commented to avoid significant slow down: Console.WriteLine($"{goodNumbersCount}-ое число: {i}");
                }
            }
            return goodNumbersCount;
        }

        static public void start()
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Добро пожаловать в программу подсчета количества \"хороших\" чисел");
            int count = countGoodNumbers(1000000000);

            Console.WriteLine($"Количество хороших чисел: {count}");
            DateTime finish = DateTime.Now;
            Console.WriteLine(finish - start);
            Console.ReadLine();
        }
    }
}
