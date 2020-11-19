using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
/*
Выполнил: Юдин Д.

Написать программу обмена значениями двух переменных:
а) с использованием третьей переменной;
б) *без использования третьей переменной.

*/
    class SwitchVariables
    {
        static public void switchValues() 
        {
            Console.WriteLine("Программа обмена значениями двух переменных запушена");
            Console.WriteLine("Введите изначальные значения переменных");
            Console.WriteLine("\n");

            Console.WriteLine("Введите значение переменной a:");
            string a = Console.ReadLine();

            Console.WriteLine("Введите значение переменной b:");
            string b = Console.ReadLine();

            string temp = a;
            a = b;
            b = temp;

            Console.WriteLine("Значения переменных были заменены. a = {0}, b = {1}", a, b);

            // Without  3rd temp variable

            Console.WriteLine("Способ 2. Работает с числовыми значениями.");
            Console.WriteLine("Введите числовое значение переменной a:");

            Console.WriteLine("\n");
            double aNum = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введите числовое значение переменной b:");
            double bNum = Double.Parse(Console.ReadLine());

            aNum = aNum + bNum;
            bNum = bNum - aNum;
            bNum = -bNum;
            aNum = aNum - bNum;

            Console.WriteLine("Значения переменных были заменены. a = {0}, b = {1}", aNum, bNum);
        }
    }
}
