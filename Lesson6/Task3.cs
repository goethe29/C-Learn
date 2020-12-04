using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson6
{
    /*
    Выполнил: Юдин Д.
    */


    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;

        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    /// <summary>
    /// Переделать программу Пример использования коллекций для решения следующих задач:
    /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    /// в) отсортировать список по возрасту студента;
    /// г) * отсортировать список по курсу и возрасту студента;
    /// </summary>
    class Task3
    {
        static int SortByFirstName(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }

        static int CourseCount(List<Student> students, string type) 
        {
            int count = 0;

            foreach (var student in students)
            {
                if ((type == "master" && student.course > 4)||
                    (type == "bachelor" && student.course < 5))
                {
                    count++;
                }
            }
            return count;
        }

        static Dictionary<int, int> CoursesStatistic(List<Student> students, int minAge, int maxAge)
        {
            Dictionary<int, int> courses = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++)
            {
                courses.Add(i, 0);
            }

            foreach (var student in students)
            {
                int q = courses[student.course];
                if (student.age >= minAge && student.age <= maxAge)
                {
                    courses[student.course] +=1;
                }
            }
            return courses;
        }

        static string PrintDictionary(Dictionary<int, int> dict) 
        {
            string result = "";
            foreach (var kvp in dict)
            {
                result += $"\n Курс: {kvp.Key}. Количество человек: {kvp.Value}";
            }
            return result;
        }

        static List<Student> LoadStudents(string file, out string exception) 
        {
            exception = "";
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(',');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    exception = e.Message;
                    return list;
                }
            }
            sr.Close();
            return list;
        }


        static public void start()
        {
            Console.WriteLine("Добро пожаловать в программу ...");

            string exception;
            List<Student> list = LoadStudents("students_6.csv",out exception);

            if (exception != "") 
            {
                Console.WriteLine(exception);
                Console.ReadLine();
                return; 
            }

            
            list.Sort(new Comparison<Student>(SortByFirstName));
            Console.WriteLine("Всего студентов:" + list.Count);

            int master = CourseCount(list, "master");
            int bachelor = CourseCount(list, "bachelor");
            Console.WriteLine("Магистров:{0}", master);
            Console.WriteLine("Бакалавров:{0}", bachelor);
            //foreach (var v in list) Console.WriteLine(v.firstName);

            Dictionary<int, int> courses = CoursesStatistic(list, 18, 20);
            Console.WriteLine(PrintDictionary(courses));
            




            Console.ReadLine();
        }
    }
}
