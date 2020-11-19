using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    /*
    Выполнил: Юдин Д.

    Ввести вес и рост человека. 
    Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h);
    где m — масса тела в килограммах, h — рост в метрах.
    */
    class BodyMassIndex
    {
        static double calculateBMI(double m, double h) 
        {
            return Math.Round(m * 1000 / (h * h), 2);
        }

        static public void startBodyMassIndex()
        {
            Console.WriteLine("Добро пожаловать в программу по расчету индекса массы тела");
            Console.WriteLine("Укажите ваш вес в кг:");
            double m = double.Parse(Console.ReadLine());
            Console.WriteLine("Укажите ваш рост в см:");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("Индекс вашей массы: {0}", calculateBMI(m, h));
        }
    }
}
