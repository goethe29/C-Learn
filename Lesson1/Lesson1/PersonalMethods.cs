using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace Lesson1
{
    class PersonalMethods
    {
        // Type message at provided position
        static public void print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
        static public void br()
        {
            Console.WriteLine("\n");
        }

        static public void wait(int ms) 
        {
            Thread.Sleep(ms);
        }

    }
}
