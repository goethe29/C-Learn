using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson5
{
    /*
    Выполнил: Юдин Д.

    Задание #1
    */

    /// <summary>
    /// Создать программу, которая будет проверять корректность ввода логина. 
    /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    /// а) без использования регулярных выражений;
    /// б) ** с использованием регулярных выражений.
    /// </summary>
    class Login
    {
        string login;
        string format = @"^[a-zA-Z][a-zA-Z0-9]{1,7}";
        bool valid;


        public Login(string login) 
        {
            this.login = login;
        }
        
        /// <summary>
        /// Validate whether login corresponds to the format.
        /// </summary>
        /// <param name="method">default/no input = default, without regular expression, regex = using reg exp</param>
        /// <returns></returns>
        bool Validate(string method="default")
        {
            if (method == "default") 
            {
                this.valid = true;
                char[] chars = this.login.ToCharArray();

                if (Char.IsNumber(chars[0]) || chars.Length < 2 || chars.Length > 8) 
                {
                    this.valid = false;
                    return this.valid;
                }

                foreach (char el in chars) 
                {
                    if (
                        !Char.IsNumber(el) &&
                        !(el >= 'a' && el <= 'z') &&
                        !(el >= 'A' && el <= 'Z')
                        )
                    {
                        this.valid = false;
                        return this.valid;
                    }
                }
            }
            else 
            {
                Regex regex = new Regex(this.format);

                this.valid = regex.IsMatch(this.login) & this.login.Length >= 2 & this.login.Length <= 8;
            }

            return this.valid;
        }

        static public void start()
        {
            Console.WriteLine("Пожалуйста придумайте новый логин.");
            Console.WriteLine("Помните, он должен соответствовать следующим правилам:");
            Console.WriteLine("* 2-8 символов");
            Console.WriteLine("* только латинские буквы или цифры");
            Console.WriteLine("* логин не может начинаться с цифры");

            bool valid;
            do
            {
                string login = Console.ReadLine();
                Login myLogin = new Login(login);
                valid = myLogin.Validate("regex");
                if (!valid)
                {
                    Console.WriteLine("Логин не соответствует правилам.");
                    Console.WriteLine("Придумайте другой:");
                }

            } while (valid == false);
            Console.WriteLine($"Логин подтвержден.");


            Console.ReadLine();
        }
    }
}
