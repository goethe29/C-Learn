using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
/*
Выполнил: Юдин Д.

а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2
по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.

*/
    class Distance
    {
        static double calculateDistance(int x1, int y1, int x2, int y2) 
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        
        static public void startDistanceProgram() 
        {
            Console.WriteLine("Программа подсчета расстояния между точками запущена.");
            Console.WriteLine("Введите координаты точек.");
            Console.WriteLine("\n");

            Console.WriteLine("x1:");
            int x1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("y1:");
            int y1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("x2:");
            int x2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("y2:");
            int y2 = Int32.Parse(Console.ReadLine());

            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            // Print variable containing result of formula assignment
            Console.WriteLine("Расстояние между точками равно: {0:F2}", r);

            // Print using method
            Console.WriteLine("Расстояние между точками равно: {0:F2}", calculateDistance(x1, y1, x2, y2));

        }
    }
}
