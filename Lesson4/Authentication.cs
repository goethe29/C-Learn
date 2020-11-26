using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson4
{
    /*
    Задание №4.
    Выполнил: Юдин Д.

    Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
    Создайте структуру Account, содержащую Login и Password.
    */
    class Authentication
    {
        struct Account
        {
         
            string Login;
            string Password;
            int authenticateLimit;

            public Account(string login, string password)
            {
                this.Login = login;
                this.Password = password;
                this.authenticateLimit = 3;
            }

            public void Authenticate(string[] credentials) 
            {
                bool logged = false;
                int tryCount = 0;
                int i = 0;

                do 
                {
                    if (credentials[i] == this.Login && credentials[i + 1] == this.Password) 
                    {
                        logged = true;
                        break;
                    }
                    i += 2;
                    tryCount++;
                }
                while (logged == false && tryCount < this.authenticateLimit && i < credentials.Length - 1);

                if (logged)
                {
                    Console.WriteLine($"Вы успешно залогинились. \nLogin: {credentials[i]} \nPassword: {credentials[i + 1]}");
                }
                else if (tryCount >= this.authenticateLimit)
                {
                    Console.WriteLine($"Вы исчерпали количество попыток. Последние проверенные креды: \n Login: {credentials[i - 2]} \nPassword: {credentials[i - 1]}");
                }
                else
                {
                    Console.WriteLine($"Ни одни креды не подошли");
                }
            }
        }

        public static string[] getCredentials(string link)
        {
            string[] credentials = new string[0];

            try
            {
                StreamReader sr = new StreamReader(link);

                int i = 0;
                while (!sr.EndOfStream)
                {
                    Array.Resize(ref credentials, credentials.Length + 2);
                    credentials[i] = sr.ReadLine();
                    credentials[i + 1] = sr.ReadLine();
                    i += 2;

                }
                sr.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            return credentials;
        }


        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу.");

            Account GeekBrains = new Account("root", "GeekBrains");

            string[] credentials = getCredentials("..\\..\\credentials.txt");

            if (credentials.Length != 0)
            {
                Console.WriteLine("\nФайл с кредам загружен.");
                Console.WriteLine("Нажмите, чтобы запустить аутентификацию..");
                Console.ReadLine();
                GeekBrains.Authenticate(credentials);
            }

            Console.ReadLine();
        }
    }
}
