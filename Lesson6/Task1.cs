using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    /*
    Выполнил: Юдин Д.
    */

    public delegate double Func(double x, double a);

    /// <summary>
    /// Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
    /// </summary>
    class Task1
    {
        /// <summary>
        /// Makes tables with result of method double(double, double) passed as parameter
        /// </summary>
        /// <param name="F"></param>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Table(Func F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// Just quadratic equation: a*x^2
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double MyQuEquation(double x, double a)
        {
            return Math.Pow(a * x, 2);
        }

        /// <summary>
        /// Calculate a*sin(x)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double MySin(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу.");

            Console.WriteLine("Таблица функции MyQuEquation:");
            Table(new Func(MyQuEquation), -2, 2, 2);

            Console.WriteLine("Таблица функции MySin:");           
            Table(MySin, -2, 2, 2);

            Console.ReadLine();
        }
    }
}
