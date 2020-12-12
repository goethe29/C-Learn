using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lesson8
{
    /// <summary>
    /// С помощью рефлексии выведите все свойства структуры DateTime
    /// </summary>
    class Task1
    {
        static public void DateTimeReflection()
        {
            Console.WriteLine("Ниже представлена рефлексия всех свойств структуры DateTime\n");
            Type t = typeof(DateTime);
            foreach (var prop in t.GetProperties())
                Console.WriteLine(prop.Name);
            Console.ReadKey();
        }
    }
}
