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
        public int num, den, snum, sden;

        public double dec;
        public bool simplified;

        /// <summary>
        /// Generate Fraction
        /// </summary>
        /// <param name="num">Numerator</param>
        /// <param name="den">Denominator</param>
        public Fraction(int num, int den)
        {
            this.num = num * den < 0 ? -1: 1;

            if (den == 0)
                throw new Exception("Знаменатель не может быть равен 0.");
            else
                this.den = Math.Abs(den);

            this.dec = (double)num / (double)den;
            this.simplified = this.reduce();
            this.simplified = false;

        }

        /// <summary>
        /// Override ToString Method to write fractions in a/b format
        /// </summary>
        /// <returns>String with fraction</returns>
        public override string ToString()
        {
            return $"{num}/{den}";
        }

        /// <summary>
        /// ToString Method to write fractions in 3 formats
        /// </summary>
        /// <param name="format">Format of output: u = a/b, s = a/b simplified, d = decimals</param>
        /// <returns>String with fraction</returns>
        public string ToString(string format)
        {
            if (format == "u") 
            {
                return $"{num}/{den}";
            }

            else if (format == "s")
            {
                return $"{snum}/{sden}";
            }

            else if (format == "d")
            {
                return $"{dec}";
            }
            return $"Неверный формат";
        }

        /// <summary>
        /// Calculate common denominator for 2 Fractions
        /// </summary>
        /// <param name="num1">1st Fraction</param>
        /// <param name="num2">2nd Fraction</param>
        /// <returns>(int) Common denominator</returns>
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

        /// <summary>
        /// Method of Fractions Addition
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of addition as a new Fraction</returns>
        public static Fraction operator +(Fraction num1, Fraction num2)
        {
            int den = commonDen(num1, num2);
            int num = den / num1.den * num1.num + den / num2.den * num2.num;
            return new Fraction(num, den);
        }

        /// <summary>
        /// Method of Fractions Substraction
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of substraction as a new Fraction</returns>
        public static Fraction operator -(Fraction num1, Fraction num2)
        {
            int den = commonDen(num1, num2);
            int num = den / num1.den * num1.num - den / num2.den * num2.num;
            return new Fraction(num, den);
        }

        /// <summary>
        /// Method of Fractions Multiplication
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of multiplication as a new Fraction</returns>
        public static Fraction operator *(Fraction num1, Fraction num2)
        {
            int den = num1.den * num2.den;
            int num = num1.num * num2.num;
            return new Fraction(num, den);
        }

        /// <summary>
        /// Method of Fractions Division
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of division as a new Fraction</returns>
        public static Fraction operator /(Fraction num1, Fraction num2)
        {
            int den = num1.den * num2.num;
            int num = num1.num * num2.den;
            return new Fraction(num, den);
        }

        /// <summary>
        /// Method of Fractions Reduction
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Simplified Fraction</returns>
        public bool reduce()
        {
            bool simplified = false;

            if (num != 1 && den != 1)
            {
                int min = num <= den ? num : den;
                int reductionRate = 1;

                for (int i = 2; i <= min; i++)
                {
                    while (num % (reductionRate * i) == 0 && den % (reductionRate * i) == 0)
                    {
                        reductionRate *= i;

                    }
                }

                if (reductionRate > 1) 
                {
                    simplified = true;
                    snum = num / reductionRate;
                    sden = den / reductionRate;
                }
            }
            return simplified;
            
        }


        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по работе с дробями");
            Fraction fraction = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(2, 4);
            Console.WriteLine(fraction);
            Console.WriteLine(fraction2);
            Console.WriteLine($"{fraction} + {fraction2} = {fraction + fraction2}");
            Console.WriteLine($"{fraction} - {fraction2} = {fraction - fraction2}");
            Console.WriteLine($"{fraction} * {fraction2} = {fraction * fraction2}");
            Console.WriteLine($"{fraction} / {fraction2} = {fraction / fraction2}");


            Console.WriteLine("Введите цифры, чтобы создать свою дробь.");

            Console.WriteLine("Числитель:");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Знаменатель:");
            int den = int.Parse(Console.ReadLine());

            Fraction inFraction;

            // Generate Fraction from user input + check exception (no Zeros in denominators!)

            try
            {
                inFraction = new Fraction(num, den);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            inFraction = new Fraction(num, den);

            Console.WriteLine($"Введенное число: {inFraction}, упрощенный вид: {inFraction.ToString("s")}, десятичная дробь:{inFraction.ToString("d")}");




            Console.ReadLine();
        }
    }
}
