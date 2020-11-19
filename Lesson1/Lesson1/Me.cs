using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
/*
Выполнил: Юдин Д.

а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) *Сделать задание, только вывод организовать в центре экрана.
в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).

*/
    class Me
    {
        static void print(string msg, int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
        static public void info() 
        {
            string name = "Дмитрий Юдин";
            string city = "Одесса";

            Console.WriteLine("Сейчас я расскажу вам немного информации о себе");
            Console.WriteLine("Меня зовут {0}. Проживаю в городе {1}. И я изучаю C#.", name, city);
            
            Console.WriteLine("А теперь тоже самое, но в центре экрана.");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("Меня зовут {0}. Проживаю в городе {1}. И я изучаю C#.", name, city);

            Console.WriteLine("\n");
            Console.WriteLine("И еще раз, но с использованием моего метода.");
            string msg = String.Format("Меня зовут {0}. Проживаю в городе {1}. И я изучаю C#.", name, city);
            print(msg,20,20);
        }
    }
}
