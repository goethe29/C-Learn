using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    class StartScreen
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №X. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. Задание №1\n" +
             "2. Задание №2\n" +
             "3. Задание №3\n" +
             "4. Задание №4\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        Task1.start();
                        break;
                    }
                case "2":
                    {
                        Task2.start();
                        break;
                    }
                case "3":
                    {
                        Task3.start();
                        break;
                    }
                case "4":
                    {
                        Task4.start();
                        break;
                    }
            }
        }
    }
}
