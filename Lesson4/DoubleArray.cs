using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ArrayClassLibrary; // My Personal Library

namespace Lesson4
{
    /*
    Задание №5.
    Выполнил: Юдин Д.

    *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
    Реализовать конструктор, заполняющий массив случайными числами. 
    Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
    свойство, возвращающее минимальный элемент массива, 
    свойство, возвращающее максимальный элемент массива, 
    метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
    **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    **в) Обработать возможные исключительные ситуации при работе с файлами.
    */
    class DoubleArray
    {
        // All program work using library
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу ...");

            Console.WriteLine("Сейчас мы сгенериуем массив:");
            MyArray2D a2 = new MyArray2D(3, 4, 1, 20);
            Console.WriteLine(a2);
            Console.WriteLine($"Минимальное число: {a2.min}");
            Console.WriteLine($"Максимальное число: {a2.max}");

            int sum = a2.Sum();
            Console.WriteLine($"Сумма всех его членов: {sum}");

            Console.WriteLine("А теперь мы сгенериуем массив из файла:");
            MyArray2D a2_fromFile = new MyArray2D("..\\..\\2d_array.txt", 4);

            if (a2_fromFile.length != 0)
            {
                Console.WriteLine(a2_fromFile);
            }

            a2_fromFile.writeTo(@"default", "generated_file_with_array.txt");

            Console.ReadLine();
        }
    }
}
