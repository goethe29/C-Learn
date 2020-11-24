using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
    */
    class OddNumbersSum
    {    
        static int sumOddNumbers(List<int> numbers) 
        {
            int sum = 0;

            foreach (int n in numbers)
            {
                if (n > 0 && n % 2 != 0)
                {
                    sum += n;
                }
            }

            return sum;
        }
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по подсчету суммы всех введенных нечетных положительных чисел.");
            Console.WriteLine("Введите все числа по порядку с новой строки. В конце введите ноль, чтобы перейти к подсчету.");
            List<int> numbers = new List<int>();
            
            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
                numbers.Add(n);
            }
            while (n != 0);

            int sum = sumOddNumbers(numbers);

            Console.WriteLine($"Cумма всех введенных нечетных положительных чисел: {sum}");
            Console.ReadLine();
        }
    }
}
