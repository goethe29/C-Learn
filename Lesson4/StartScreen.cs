using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    class StartScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №X. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. ...\n" +
             "2. ...\n" +
             "3. ...\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        Template.start();
                        break;
                    }
                case "2":
                    {
                        Template.start();
                        break;
                    }
                case "3":
                    {
                        Template.start();
                        break;
                    }
            }
        }
    }
}
