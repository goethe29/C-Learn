using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Lesson5
{
    /*
    Выполнил: Юдин Д.

    Задание #4
    */

    /// <summary>
    /// *Задача ЕГЭ.
    /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
    /// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
    /// каждая из следующих N строк имеет следующий формат:<Фамилия> <Имя> <оценки>, 
    ///     где<Фамилия> — строка, состоящая не более чем из 20 символов, 
    ///     <Имя> — строка, состоящая не более чем из 15 символов, 
    ///     <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    ///     <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. 
    ///     Пример входной строки:Иванов Петр 4 5 3
    /// Требуется написать как можно более эффективную программу, 
    ///     которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
    /// Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
    /// </summary>

    struct Student
    {
        public string firstName;
        public string lastName;
        public double average;

        public Student(string lastName, string firstName, double average)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.average = average;
        }

    }

    class Exam
    {
        public bool fileExists;
        public string error;
        public int defaultPrintNum = 3;

        /// <summary>
        /// Reads file (where 2st line - N of students, other lines - LastName FirstName int int int) and generate Student Array 
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public Student[] LoadData(string link) 
        {
            Student[] students = new Student[0];
            StreamReader file;
            
            try
            {
                file = new StreamReader(link);
            }
            catch (Exception ex)
            {
                fileExists = false;
                this.error = ex.Message;
                return students;
            }

            int n = int.Parse(file.ReadLine());
            Array.Resize(ref students, n);

            for (int i = 0; i < n; i++) 
            {
                string line = file.ReadLine();
                string[] elements = line.Split(new char[] { ' ' });

                double average = Math.Round((double)(int.Parse(elements[2]) + int.Parse(elements[3]) + int.Parse(elements[4])) / 3, 2);
                students[i] = new Student(elements[0], elements[1], average);
            }
            fileExists = true;
            return students;
        }

        /// <summary>
        /// Takes Student Array and returnes new Array sorted by Average in asc order
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public Student[] SortStudents(Student[] students) 
        {
            Student[] sortedStudents = new Student[students.Length];
            Array.Copy(students, sortedStudents, students.Length);

            Array.Sort(sortedStudents, delegate (Student student1, Student student2)
            {
                return student1.average.CompareTo(student2.average);
            });
            return sortedStudents;
        }

        /// <summary>
        /// Prints Student array in lines
        /// </summary>
        /// <param name="students"></param>
        /// <param name="num">maximum number of different average to print</param>
        /// <returns></returns>
        public string Print(Student[] students, int num = 0 ) 
        {
            int l = students.Length;
            
            if (num == 0)
            {
                num = students.Length;
            }

            string str = "";
            
            // student with different point listed number
            int s = 0;

            for (int i = 0; i < l; i++)
            {
                s++;
                Student student = students[i];
                str += $"\n Имя: {student.lastName} {student.firstName}. Средний балл: {student.average}";

                if (i != l-1)
                {
                    Student nextStudent = students[i + 1];
                    if (nextStudent.average == student.average||
                        (nextStudent.average != student.average && s < num)
                        )
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return str;
        }

        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу.");

            Exam exam = new Exam();

            Student[] students = exam.LoadData("..\\..\\students.txt");

            if (exam.fileExists == false)
            {
                Console.WriteLine(exam.error);
            }
            else
            {
                Console.WriteLine($"Загружены следующие Студенты {exam.Print(students, 0)}");
                Student[] sortedStudents = exam.SortStudents(students);
                Console.WriteLine($"Студенты отсортированы по возрастанию среднего балла");
                int q = 3;

                Console.WriteLine($"Студенты c {q} наинизшими средними баллами {exam.Print(sortedStudents, q)}");
            }

            Console.ReadLine();
        }
    }
}
