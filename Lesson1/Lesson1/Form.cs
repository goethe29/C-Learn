using System;

namespace Lesson1
{
/*
Выполнил: Юдин Д.

Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
В результате вся информация выводится в одну строчку:
    а) используя  склеивание;
	б) используя форматированный вывод;
	в) используя вывод со знаком $.
*/
    class Form
    {
        static public void askUser() 
        {
            Console.WriteLine("Добро пожаловать. Сейчас вам зададут несколько вопросов. Введите любой символ, чтобы начать.");
            Console.ReadLine();

            Console.WriteLine("Ваше имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия:");
            string lastname = Console.ReadLine();

            // As we are not going to make some math with Age/Height/Weight, let it be just string variables
            Console.WriteLine("Ваш возраст:");
            string age = Console.ReadLine();
            Console.WriteLine("Ваш рост в см:");
            string height = Console.ReadLine();
            Console.WriteLine("Ваш вес в кг:");
            string weight = Console.ReadLine();

            // Concatenate
            Console.WriteLine("Получены следующие данные: " + name + " " + lastname + ", " + age + " лет, " + height + " см, " + weight + " кг");
            
            // Composite formatting
            Console.WriteLine("Получены следующие данные: {0} {1}, {2} лет, {3} см, {4} кг", name, lastname, age, height, weight);

            // String interpolation
            Console.WriteLine($"Получены следующие данные: {name} {lastname}, {age} лет, {height} см, {weight} кг");
        }
    }
}
