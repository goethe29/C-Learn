using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    class StartScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №3. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. Cтруктура/класс Complex.\n" +
             "2. Расчет суммы всех нечетных положительных чисел.\n" +
             "3. Класс дробей\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        ComplexNumbers.start();
                        break;
                    }
                case "2":
                    {
                        OddNumbersSum.start();
                        break;
                    }
                case "3":
                    {
                        Fractions.start();
                        break;
                    }
            }
        }
    }
}
