using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    class StartScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №4. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. Задача №1\n" +
             "2. Задача №2\n" +
             "3. Задача №3\n" +
             "4. Задача №4\n" +
             "5. Задача №5\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        ArrayProgram.start();
                        break;
                    }
                case "2":
                    {
                        StaticArray.start();
                        break;
                    }
                case "3":
                    {
                        SingleArray.start();
                        break;
                    }
                case "4":
                    {
                        Authentication.start();
                        break;
                    }
                case "5":
                    {
                        Template.start();
                        break;
                    }
            }
        }
    }
}
