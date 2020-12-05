using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson6
{
    /*
    Выполнил: Юдин Д.
    */

    /// <summary>
    /// **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
    /// Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.
    /// </summary>
    class Task4
    {
        /// <summary>
        /// Reads bites from file and save to byte[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static byte[] FileStreamLoad(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];

            for (int i = 0; i < fs.Length; i++)
            {
                bytes[i] = (byte)fs.ReadByte();
            }
            fs.Close();
            return bytes;
        }

        /// <summary>
        /// Reads bites from file using buffer and save to byte[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static byte[] BufferedStreamLoad(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fs.Length];
            int countPart = 4;
            int bufsize = (int)(fs.Length / countPart);

            BufferedStream bs = new BufferedStream(fs, bufsize);
            for (int i = 0; i < countPart; i++)
            {
                bs.Read(buffer, 0, (int)bufsize);
            }
            fs.Close();
            return buffer;
        }


        /// <summary>
        /// Reads lines from file and save to string
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static string StreamReaderLoad(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = "";

            while (!sr.EndOfStream)
            {
                str += sr.ReadLine() + "\n";
            }
            fs.Close();
            return str;
        }

        /// <summary>
        /// Reads bites from file and save to int[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static int[] BinaryStreamLoad(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int[] integers = new int[fs.Length];

            for (int i = 0; i < fs.Length / sizeof(int); i++)
            {
                integers[i] = br.ReadInt32();
            }
            fs.Close();
            return integers;
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу.");

            string file = "task4_data.txt";

            Console.WriteLine("\nЗагружаем данные с помощью FileStream и сохраняем в byte[].");
            byte[] fileStream = FileStreamLoad(file);
            Console.WriteLine(fileStream);

            Console.WriteLine("\nЗагружаем данные с помощью BufferedStream и сохраняем в byte[].");
            byte[] bufferedStream = BufferedStreamLoad(file);
            Console.WriteLine(bufferedStream);

            Console.WriteLine("\nЗагружаем данные с помощью BinaryStream и сохраняем в int[].");
            int[] binaryStream = BinaryStreamLoad(file);
            Console.WriteLine(binaryStream);

            Console.WriteLine("\nЗагружаем данные с помощью StreamReaded и сохраняем в string.");
            string streamReader = StreamReaderLoad(file);
            Console.WriteLine(streamReader);

            Console.ReadLine();
        }
    }
}
