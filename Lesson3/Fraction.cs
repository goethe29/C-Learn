using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    /*
    Выполнил: Юдин Д.

    Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
    Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
    Написать программу, демонстрирующую все разработанные элементы класса.
    * Добавить свойства типа int для доступа к числителю и знаменателю;
    * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    *** Добавить упрощение дробей.


    */
    class Fraction
    {
        // num = numerator, displayed above a line(or before a slash), denom = a non-zero denominator, below a line
        public int num, den;

        public Fraction(int num, int den) 
        {
            this.num = num;
            this.den = den;
        }

        public override string ToString()
        {
            int oldNum;
            int oldDen;

            if (num == 0)
            {
                return "0";
            }
            else if (den == 1)
            {
                return $"{num}/{den} (упрощенный вариант: {num})";
            }

            else if (this.reduce(out oldNum,out oldDen) == true) 
            {
                return $"{oldNum}/{oldDen} (упрощенный вариант: {num}/{den})";
            }

            return $"{num}/{den}";
        }

        public static int commonDen(Fraction num1, Fraction num2) 
        {
            int den;

            if (num1.den == num2.den || num1.den % num2.den == 0)
            {
                den = num1.den;
            }
            else if (num2.den % num1.den == 0)
            {
                den = num2.den;
            }

            else 
            {
                den = num1.den * num2.den;
            }

            return den;
        }
        
        public static Fraction operator +(Fraction num1, Fraction num2) 
        {
            int den = commonDen(num1, num2);
            int num = den/num1.den * num1.num + den/num2.den * num2.num;
            return new Fraction(num, den);
        }

        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            int den = commonDen(num1, num2);
            int num = den / num1.den * num1.num - den / num2.den * num2.num;
            return new Fraction(num, den);
        }

        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            int den = num1.den * num2.den;
            int num = num1.num * num2.num;
            return new Fraction(num, den);
        }

        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            int den = num1.den * num2.num;
            int num = num1.num * num2.den;
            return new Fraction(num, den);
        }

        public bool reduce(out int oldNum, out int oldDen)
        {
            bool reduced;
            oldNum = num;
            oldDen = den;

            if (num == 1 || den == 1) 
            {
                return reduced = false;
            }

            int min = num <= den ? num : den;
            int reductionRate = 1;
            
            for (int i = 2; i <= min; i++) 
            {
                int q = i;
                while (num % q == 0 && den % q == 0) 
                {
                    reductionRate *= i;
                    q *= q;
                } 
            }
            reduced = reductionRate > 1 ? true : false;
            oldNum = num;
            num /= reductionRate;
            oldDen = den;
            den /= reductionRate;
            return reduced;
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по работе с дробями");
            Fraction fraction = new Fraction(1, 2);
            Fraction fraction2= new Fraction(2, 4);
            Console.WriteLine(fraction);
            Console.WriteLine(fraction2);
            Console.WriteLine($"{fraction} + {fraction2} = {fraction + fraction2}");
            Console.WriteLine($"{fraction} - {fraction2} = {fraction - fraction2}");
            Console.WriteLine($"{fraction} * {fraction2} = {fraction * fraction2}");
            Console.WriteLine($"{fraction} / {fraction2} = {fraction / fraction2}");

            Console.ReadLine();
        }
    }
}
