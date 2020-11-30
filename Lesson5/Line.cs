using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    /*
    Выполнил: Юдин Д.

    Задание #3
    */

    /// <summary>
    /// *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    /// Например:badc являются перестановкой abcd.
    /// </summary>
    class Line
    {
        /// <summary>
        /// Sorts characters in the string and returns a new string to allow compare method
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string SortString(string text)
        {
            char[] characters = text.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        /// <summary>
        /// Compare 2 strings: marks as identic if equal intially, marks as semi-identic if equal after soring,  else marks as completly different
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        static string Compare(string text1, string text2) 
        {
            string message = "";

            if (text1 == text2)
            {
                message = "Строки полностью равны";
            }
            else if (SortString(text1) == SortString(text2))
            {
                message = "Строки являются перестановкой друг друга";
            }
            else
            {
                message = "Строки являются разными";
            }
            
            return message;
        }


        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу ...");

            Console.WriteLine("Введите первую строку:");
            string text1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку:");
            string text2 = Console.ReadLine();

            Console.WriteLine($"Сравниваем строки...");
            Console.WriteLine($"Результат: {Compare(text1, text2)}.");




            Console.ReadLine();
        }
    }
}
