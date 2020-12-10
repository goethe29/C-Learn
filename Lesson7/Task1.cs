using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Lesson7
{
    /*
        Выпонил: Юдин Д.   
 
    */

    /// <summary>
    /// Class to save game actions
    /// </summary>
    public class Game 
    {
        public List<int> steps;
        public int commands;
        public int targetNum;
        bool win;

        public Game() 
        {
            steps = new List<int>();
            commands = 0;
            Random r = new Random();
            targetNum = r.Next(2,1000);
            win = false;
        }


        /// <summary>
        /// Saves game steps (number received) to the List
        /// </summary>
        /// <param name="n"></param>
        public void SaveStep(int n)
        {
            this.steps.Add(n);
            commands += 1;
        }

        /// <summary>
        /// Remove the last step
        /// </summary>
        /// <returns></returns>
        public int ReturnBack()
        {
            if (steps.Count > 1)
            {
                this.steps.RemoveAt(steps.Count - 1);
            }
            commands += 1;
            return this.steps[steps.Count - 1];
        }
    }
    
    /// <summary>
    /// а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    /// б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
    ///     Игрок должен получить это число за минимальное количество ходов.
    /// в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
    ///     Используйте обобщенный класс Stack.
    /// Вся логика игры должна быть реализована в классе с удвоителем.

    /// </summary>
    static class Task1
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Task1Menu());
        }

    }
}
