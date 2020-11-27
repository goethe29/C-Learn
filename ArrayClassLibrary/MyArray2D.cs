using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArrayClassLibrary
{
    public class MyArray2D
    {
        int[,] a2;
        public string maxIndex;

        /// <summary>
        /// Generate array with lines and columnts set, filled by random numbers from min to max
        /// </summary>
        /// <param name="n">  size of array</param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        public MyArray2D(int lines, int columns, int min, int max)
        {
            a2 = new int[lines, columns];
            Random r = new Random();

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    a2[i, j] = r.Next(min, max);
                }
            }
        }

        /// <summary>
        /// Generate new Array from file with set numbers of columns
        /// </summary>
        /// <param name="link"></param>
        /// <param name="columns"></param>
        public MyArray2D(string link, int columns)
        {
            try
            {
                StreamReader sr = new StreamReader(link);

                int linesConunt = TotalLines(link);
                a2 = new int[linesConunt / columns + linesConunt % columns, columns];

                int i = 0;
                int j = 0;

                while (!sr.EndOfStream)
                {

                    a2[i, j] = int.Parse(sr.ReadLine());

                    if (j != 0 && j == columns - 1)
                    {
                        j = 0;
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int this[int i, int k]
        {
            get
            {
                int n = a2[i, k];

                return n;
            }
        }

        /// <summary>
        /// Length of the array
        /// </summary>
        public int length
        {
            get
            {
                return this.a2.Length;
            }
        }

        /// <summary>
        /// Min number in array
        /// </summary>
        public int min
        {
            get
            {
                int min = a2[0, 0];

                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        if (a2[i, j] < min)
                        {
                            min = a2[i, j];
                        }
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Max number in array
        /// </summary>
        public int max
        {
            get
            {
                int max = a2[0, 0];

                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        if (a2[i, j] > max)
                        {
                            max = a2[i, j];
                        }
                    }
                }
                indexOf(max, out maxIndex); // Find Index of Max number
                return max;
            }
        }

        /// <summary>
        /// Find Key in Array and return it index
        /// </summary>
        /// <param name="key">What to search</param>
        /// <param name="index">Where to return index</param>
        public void indexOf(int key, out string index) 
        {
            index = "-1. -1";
            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    if (a2[i, j] == key)
                    {
                        index = i + ", " + j;
                    }
                }
            }
        }

        /// <summary>
        /// Print array (class) as string
        /// </summary>
        public override string ToString()
        {
            string array = "";

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    array += a2[i, j] + " ";
                }
                array += "\n";
            }
            return array;
        }

        /// <summary>
        /// Calculate the sum of all members of 2D Array
        /// </summary>
        /// <returns>int sum</returns>
        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < a2.GetLength(0); i++)
            {
                for (int j = 0; j < a2.GetLength(1); j++)
                {
                    sum += a2[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Write array elements as lines into files. Creates a new file if didn't found existing.
        /// </summary>
        /// <param name="link">Link to folder where where file is located. Type "default" to save in the project folder</param>
        /// <param name="filename">Name of the file, e.g.: example.txt</param>
        public void writeTo(string link, string filename)
        {
            if (link == "default")
            {
                link = "..\\..\\";
            }
            else
            {
                link += "\\";
            }

            link += filename;

            try
            {
                StreamWriter file = new StreamWriter(link);

                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        file.WriteLine(a2[i, j]);
                    }
                }
                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Calculate the number of lines in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
    }
}
