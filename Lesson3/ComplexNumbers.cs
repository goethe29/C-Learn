using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    /*
    Выполнил: Юдин Д.

    а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
    б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
    в) Добавить диалог с использованием switch демонстрирующий работу класса.
    */

    struct sComplex
    {
        public double re, im;

        /// <summary>
        /// Main properties of Complex Numbers
        /// </summary>
        /// <param name="re">Real Number</param>
        /// <param name="im">Imaginary Number</param>
        public sComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        /// <summary>
        /// Generate string with complex number
        /// </summary>
        /// <returns> Complex Numbers as string: a + bi</returns>
        public override string ToString()
        {
            return $"{re} + {im}i";
        }

        /// <summary>
        /// Method of Complex Numbers Addition
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of addition as a new Complex Number</returns>
        public static sComplex operator +(sComplex num1, sComplex num2)
        {
            return new sComplex(
                re: num1.re + num2.re,
                im: num1.im + num2.im
                );
        }

        /// <summary>
        /// Method of Complex Numbers Substraction
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Result of substraction as a new Complex Number</returns>
        public static sComplex operator -(sComplex num1, sComplex num2)
        {
            return new sComplex(
                re: num1.re - num2.re,
                im: num1.im - num2.im
                );
        }
    }

    class ComplexNumber
    {
        // The same as the struct above, but class
        class cComplex
        {
            public double re, im;

            /// <summary>
            /// Main properties of Complex Numbers
            /// </summary>
            /// <param name="re">Real Number</param>
            /// <param name="im">Imaginary Number</param>
            public cComplex(double re, double im)
            {
                this.re = re;
                this.im = im;
            }
            /// <summary>
            /// Generate string with complex number
            /// </summary>
            /// <returns> Complex Numbers as string: a + bi</returns>
            public override string ToString()
            {
                return $"{re} + {im}i";
            }

            /// <summary>
            /// Method of Complex Numbers Addition
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns>Result of addition as a new Complex Number</returns>
            public static cComplex operator +(cComplex num1, cComplex num2)
            {
                return new cComplex(
                    re: num1.re + num2.re,
                    im: num1.im + num2.im
                    );
            }

            /// <summary>
            /// Method of Complex Numbers Substraction
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns>Result of substraction as a new Complex Number</returns>
            public static cComplex operator -(cComplex num1, cComplex num2)
            {
                return new cComplex(
                    re: num1.re - num2.re,
                    im: num1.im - num2.im
                    );
            }

            /// <summary>
            /// Method of Complex Numbers Multiplication
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns>Result of multiplication as a new Complex Number</returns>
            public static cComplex operator *(cComplex num1, cComplex num2)
            {
                return new cComplex(
                    re: num1.re * num2.re,
                    im: num1.im * num2.im
                    );
            }
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу по работе с комплексными числами");

            sComplex num1 = new sComplex(1, 2);
            sComplex num2 = new sComplex(3, 4);
            
            Console.WriteLine("Сначала продемонстрируем работу структуры.");
            Console.WriteLine($"Даны 2 числа. Число 1: {num1}, число 2: {num2}");

            sComplex sum = num1 + num2;
            Console.WriteLine($"Сумма двух чисел: {sum}");

            sComplex diff = num1 - num2;
            Console.WriteLine($"Разница двух чисел: {diff}");

            Console.WriteLine("Нажмите любую букву для перехода к работе класса.");
            Console.ReadLine();

            ComplexNumber.cComplex num3 = new ComplexNumber.cComplex(2, 2);
            ComplexNumber.cComplex num4 = new ComplexNumber.cComplex(3, 3);
            Console.WriteLine($"Даны 2 числа. Число 1: {num3}, число 2: {num4}");
            Console.WriteLine(
              "Выберите, что сделать с числами:\n" +
             "1. Сложить.\n" +
             "2. Вычесть 2ое из 1го\n" +
             "3. Умножить\n" +
             "0. Выйти\n" +
             "\n");

            string choice = "";
            do
            {
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            ComplexNumber.cComplex sum2 = num3 + num4;
                            Console.WriteLine($"Сумма двух чисел: {sum2}");
                            break;
                        }
                    case "2":
                        {
                            ComplexNumber.cComplex diff2 = num3 - num4;
                            Console.WriteLine($"Разница двух чисел: {diff2}");
                            break;
                        }
                    case "3":
                        {
                            ComplexNumber.cComplex product2 = num3 * num4;
                            Console.WriteLine($"Произведение двух чисел: {product2}");
                            break;
                        }
                }

            } while (choice != "0");

            Console.ReadLine();
        }
    }
}
