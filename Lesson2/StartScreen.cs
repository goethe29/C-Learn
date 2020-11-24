using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class StartScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №2. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. Подсчет минимального из любого количества чисел.\n" +
             "2. Подсчет количества цифр числа.\n" +
             "3. Расчет суммы всех нечетных положительных чисел.\n" +
             "4. Проверка логина и пароля\n" +
             "5. Расчет индекса массы тела\n" +
             "6. Подсчет количества \"хороших\" чисел\n" +
             "7. Рекурсивный метод вывода на экран чисел от a до b(a<b)\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        MinNumber.start();
                        break;
                    }
                case "2":
                    {
                        DigitsCount.start();
                        break;
                    }
                case "3":
                    {
                        OddNumbersSum.start();
                        break;
                    }
                case "4":
                    {
                        Authentication.start();
                        break;
                    }
                case "5":
                    {
                        BodyMassIndex.start();
                        break;
                    }
                case "6":
                    {
                        GoodNumbers.start();
                        break;
                    }
                case "7":
                    {
                        RecursionExample.start();
                        break;
                    }
            }
        }
    }
}
