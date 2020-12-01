using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
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
             "4. ...\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        Login.start();
                        break;
                    }
                case "2":
                    {
                        Message.start();
                        break;
                    }
                case "3":
                    {
                        Line.start();
                        break;
                    }
                case "4":
                    {
                        Exam.start();
                        break;
                    }
            }
        }
    }
}
