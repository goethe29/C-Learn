using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    /*
    Выполнил: Юдин Д.

   а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
    Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.
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
            Console.WriteLine("Введите все числа по порядку с новой строки. Обратите внимание, все отрицательные и четные числа будут проигнорированы.\n" +
                "В конце введите ноль, чтобы перейти к подсчету.");
            List<int> numbers = new List<int>();
            
            int n;
            string s;
            bool valid;

            do
            {
                do
                {
                    s = Console.ReadLine();
                    valid = int.TryParse(s, out n);

                    if (!valid)
                    {
                        Console.WriteLine("Введите число, не букву, не символ, не изображение, а ЧИСЛО. \n" +
                            "Пожалуйста, воспользуйтесь гуглом, если вы забыли как выглядят числа");
                    }
                } while (!valid);

                numbers.Add(n);
            }
            while (n != 0);

            int sum = sumOddNumbers(numbers);

            Console.WriteLine($"Cумма всех введенных нечетных положительных чисел: {sum}");
            Console.ReadLine();
        }
    }
}
