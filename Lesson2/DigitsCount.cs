using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    Написать метод подсчета количества цифр числа.
    */
    class DigitsCount
    {
        static int countDigits(int number) 
        {
            if (number == 0)                                 
                return 0;                              
            else return countDigits(number / 10) + 1;   
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу подсчета количества цифр числа");
            Console.WriteLine("Укажите число:");
            int n = int.Parse(Console.ReadLine());

            int digits = countDigits(n);
            Console.WriteLine($"Количество цифр в указанном числе: {digits}");
            Console.ReadLine();
        }
    }
}
