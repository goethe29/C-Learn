using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    class StartScreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в сборник задач из Урока №1. Вам на выбор представлены:");
            Console.WriteLine(
            "\n" +
             "1. Анкета\n" +
             "2. Расчет индекса массы тела\n" +
             "3. Измерение расстояния между точками\n" +
             "4. Обмен значений 2 переменных\n" +
             "5. Информация обо мне\n" +
             "\n"
             );
            Console.WriteLine("Введите цифру, чтобы продолжить:");

            string choice = Console.ReadLine();
            Console.WriteLine("\n");

            switch (choice)
            {
                case "1":
                    {
                        Form.askUser();
                        break;
                    }
                case "2":
                    {
                        BodyMassIndex.startBodyMassIndex();
                        break;
                    }
                case "3":
                    {
                        Distance.startDistanceProgram();
                        break;
                    }
                case "4":
                    {
                        SwitchVariables.switchValues();
                        break;
                    }
                case "5":
                    {
                        Me.info();
                        break;
                    }
            }
        }
    }
}
