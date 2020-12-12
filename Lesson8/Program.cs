using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите что запустить:\n\n" +
                "0. Форму с вопросами\n" +
                "1. Задание 1\n" +
                "2. Задание 2\n" +
                "3. Задание 3\n" +
                "4. Задание 4\n" +
                "5. Задание 5\n"
                );
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;
                case "1":
                    Task1.DateTimeReflection();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
        }
    }
}
