using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Lesson6
{
    /*
    Выполнил: Юдин Д.
    */

    public delegate double Func2(double x);

    /// <summary>
    /// Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
    /// а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
    ///     Использовать массив(или список) делегатов, в котором хранятся различные функции.
    /// б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
    ///     Пусть она возвращает минимум через параметр(с использованием модификатора out). 
    /// </summary>
    class Task2
    {
        /// <summary>
        /// F(x * x - 50 * x + 10)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double MyFunc(double x)
        {
            return x * x - 50 * x + 10;
        }

        /// <summary>
        /// F(x^2)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double fSquare(double x)
        {
            return x * x;
        }

        /// <summary>
        /// F(x^3)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double fCube(double x)
        {
            return x * x * x;
        }

        /// <summary>
        /// F(x+2)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double fAddTwo(double x)
        {
            return x + 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="F">Function to Use</param>
        /// <param name="fileName"> File to save results</param>
        /// <param name="x">Initial number to use in function</param>
        /// <param name="max">Maximum range for function</param>
        /// <param name="step">Step of x increment for every new iteration</param>
        public static void SaveFunc(Func2 F, string fileName, double x, double max, double step)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (x <= max)
            {
                bw.Write(F(x));
                x += step;
            }
            bw.Close();
            fs.Close();
        }
        
        /// <summary>
        /// Load file with function calculation results
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            
            long q = fs.Length;
            double[] numbers = new double[q];

            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            for (int i = 0; i < q / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                numbers[i] = d;
                if (d < min) min = d;

            }
            bw.Close();
            fs.Close();
            return numbers;
        }

        /// <summary>
        /// Generate menu based on the List with Function Delegates
        /// </summary>
        /// <param name="functions"> List of  delegate functions</param>
        /// <returns></returns>
        public static string Menu(List<Func2> functions) 
        {
            string menu = "";

            int i = 0;
            foreach (var function in functions)
            {
                string fName = GetFunctionName(function);

                switch (fName)
                {
                    case"MyFunc":
                        {
                            fName = "F(x * x - 50 * x + 10)";
                            break;
                        }
                    case "fSquare":
                        {
                            fName = "F(x^2)";
                            break;
                        }
                    case "fCube":
                        {
                            fName = "F(x^3)";
                            break;
                        }
                    case "fAddTwo":
                        {
                            fName = "F(x+2)";
                            break; 
                        }
                    default:
                        break;
                }

                menu += $"{i}. {fName}\n";
                i++;
            }
            return menu;
        }

        /// <summary>
        /// Get Method Name
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public static string GetFunctionName(Delegate function)
        {
            return function.Method.Name;
        }

        /// <summary>
        /// Interact with User via Console to get Double number
        /// </summary>
        /// <returns></returns>
        public static double getDouble() 
        {
            double n;
            bool doubleReceived = false;
            do
            {
                string input = Console.ReadLine();
                doubleReceived = double.TryParse(input, out n);
                if (!doubleReceived)
                {
                    Console.WriteLine("Не удалось преобразовать в double. Введите еще раз");
                }
            } while (!doubleReceived);

            return n;
        }
        
        /// <summary>
        /// Interact with User via Console to get input for SaveFunc method
        /// </summary>
        /// <param name="functions">List of functions</param>
        /// <param name="n">Number of function to use</param>
        /// <param name="x">Initial number</param>
        /// <param name="max">Maximum number</param>
        /// <param name="step">Step for calculation</param>
        public static void UserInput(List<Func2> functions, out int n, out double x, out double max, out double step) 
        {
            bool numberReceived = false;
            n = 0;
            step = 1;
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (Char.IsNumber(c))
                {
                    n = int.Parse(c.ToString());

                    if (n < functions.Count)
                    {
                        numberReceived = true;
                    }
                    else
                    {
                        Console.WriteLine("\nВведенное число за границами диапазона.");
                    }
                }
                else
                {
                    Console.WriteLine("\nВведеный символ неверен.");
                }
            } while (!numberReceived);

            Console.WriteLine("\nТеперь введите double x для расчета функции. E.g: 6,75");
            x = getDouble();

            Console.WriteLine("\nТеперь введите double max (верхняя граница рассчетов.");
            max = getDouble();

            Console.WriteLine("\nТеперь введите double шаг расчет функции.");
            step = getDouble();
        }

        static public void start()
        {
            List<Func2> functions = new List<Func2>();
            functions.Add(fAddTwo);
            functions.Add(fCube);
            functions.Add(fSquare);
            functions.Add(MyFunc);

            string menu = Menu(functions);
            Console.WriteLine($"На выбор предложены следующие функции: \n{menu}");
            Console.WriteLine("Введите номер функции, которую хотите проверить");

            int n;
            double x;
            double max;
            double step;
            UserInput(functions,out n, out x,out max, out step);
            SaveFunc(functions[n], "data.bin", x, max, step);
            Load("data.bin", out double min);
            Console.WriteLine($"Минимальный результат: {min}");

            Console.ReadLine();
        }
    }
}
