using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    /*
    Выполнил: Юдин Д.

    Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
    На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
    программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
    */
    class Authentication
    {
        static string _login = "root";
        static string _pass = "GeekBrains";
        static bool authenticate(string login, string pass) 
        {
            return login == _login && pass == _pass;
        }
        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу проверки логина и пароля");
            int tryCount = 0;
            bool authenticated;


            do
            {
                Console.WriteLine("Введите логин:");
                string login = Console.ReadLine();

                Console.WriteLine("Введите пароль:");
                string pass = Console.ReadLine();

                authenticated = authenticate(login, pass);
                tryCount++;

                if (!authenticated) 
                {
                    Console.WriteLine("Вы ввели неверный пароль или пользователь с указанным логином не найден");
                }
            }
            while (tryCount < 3 && !authenticated);

            Console.WriteLine(authenticated ? "Вы успешно прошли аутентификацию" : "Количество попыток исчерпано. Пожалуйста, перезапустите программу, чтобы попробовать еще раз");
            Console.ReadLine();
        }
    }
}
