using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lesson8
{
    /// <summary>
    /// **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
    /// </summary>
    class Task5
    {
        static string exception;
        static void ToXML(string fileName, string fileTo)
        {
            List<Student> list = Student.LoadStudents(fileName, out exception);

            if (exception != "")
            {
                Console.WriteLine($"Файл не найден: {fileName}");
                return;
            }

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileTo, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        static public void start() 
        {
            ToXML("students_6.csv", "students.xml");
            if (exception != "")
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Данные успешно загружены из CSV и сохранены в XML");
            
            Console.ReadKey();
        }
    }
}
