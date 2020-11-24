using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы
    и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
    б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

    */
    class BodyMassIndex
    {

        static bool giveAdvice;
        static double m;
        static double h;

        static string advise(double index) 
        {
            if (index >= 18.5 && index <= 24.99)
            {
                return "Соотношения вашего роста и массы в норме";
            }
            else if (index > 24.99)
            {
                giveAdvice = true;
                return "У вас избыточная масса тела";
            }
            else 
            {
                giveAdvice = true;
                return "У вас недостаточная (дефицит) масса тела";
            }
        }

        static string advancedAdvise(double index)
        {
            double m2;

            if (index < 18.5)
            {
                m2 = Math.Round((18.5 - index) * (h * h) / 10000, 2);
                return $"Вам нужно набрать: {m2} кг";
            }
            else
            {
                m2 = Math.Round((index - 24.99) * (h * h) / 10000, 2);
                return $"Вам нужно сбросить: {m2} кг";
            }
        }

        static double calculateBMI(double m, double h) 
        {
            return Math.Round(m * 10000 / (h * h), 2);
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по расчету индекса массы тела");
            Console.WriteLine("Укажите ваш вес в кг:");
            m = double.Parse(Console.ReadLine());
            Console.WriteLine("Укажите ваш рост в см:");
            h = double.Parse(Console.ReadLine());

            double index = calculateBMI(m, h);
            Console.WriteLine("Индекс вашей массы: {0}", index);

            Console.WriteLine(advise(index));

            if (giveAdvice) 
            {
                Console.WriteLine(advancedAdvise(index)); 
            }

            Console.ReadLine();
        }
    }
}
