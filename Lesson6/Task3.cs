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
    static class Task3
    {
        /// <summary>
        /// Sorts Students by First Name
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int SortByFirstName(Student st1, Student st2)
        {
            return String.Compare(st1.firstName, st2.firstName);
        }

        /// <summary>
        /// Sorts Students by Age
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int SortByAge(Student st1, Student st2)
        {
            if (st1.age == st2.age)
            {
                return 0;
            }
            else if (st1.age > st2.age)
            {
                return 1;
            }
            else
                return -1; 
        }

        /// <summary>
        /// Sorts Students by Course, then by Age in the frame of 1 course
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int SortByCourseAge(Student st1, Student st2)
        {
            if (st1.course == st2.course)
            {
                return SortByAge(st1, st2);
            }
            else if (st1.course > st2.course)
            {
                return 1;
            }
            else
                return -1;
        }


        /// <summary>
        /// Counts numbers of student on the bachelor/master courses
        /// </summary>
        /// <param name="students"> List of students</param>
        /// <param name="type">Type "master" to count masters or "bachelor" to count bachelors</param>
        /// <returns></returns> 
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

        /// <summary>
        /// Counts numbers of student with age >= min && age <= max on the all courses
        /// </summary>
        /// <param name="students"></param>
        /// <param name="minAge"></param>
        /// <param name="maxAge"></param>
        /// <returns>Dictionary<int, int>: Course Num, Students Qty</int>></returns>
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

        /// <summary>
        /// Generate string from Dictionary with every key-value pair on the new line: "Курс: i. Количество человек: n"
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        static string PrintDictionary(Dictionary<int, int> dict) 
        {
            string result = "";
            foreach (var kvp in dict)
            {
                result += $"Курс: {kvp.Key}. Количество человек: {kvp.Value}\n";
            }
            return result;
        }

        /// <summary>
        /// Prints Students List to console as: "FirstName LastName, age. Курс: сourse"
        /// </summary>
        /// <param name="list"></param>
        public static void Print(this List<Student> list) 
        {
            foreach (var v in list)
            {
                Console.WriteLine($"{v.firstName} {v.lastName}, {v.age}. Курс: {v.course}");
            }
        }
        
        /// <summary>
        /// Loads students from the prepared csv and saves to the List
        /// </summary>
        /// <param name="file"></param>
        /// <param name="exception">Error message if exception caught</param>
        /// <returns></returns>
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

            // Load data
            string exception;
            List<Student> list = LoadStudents("students_6.csv",out exception);

            if (exception != "") 
            {
                Console.WriteLine(exception);
                Console.ReadLine();
                return; 
            }

            // Sort by First Name and print total count of students
            list.Sort(new Comparison<Student>(SortByFirstName));
            Console.WriteLine("Всего студентов:" + list.Count);

            // Count masters/bachelors
            int master = CourseCount(list, "master");
            int bachelor = CourseCount(list, "bachelor");
            Console.WriteLine("Магистров:{0}", master);
            Console.WriteLine("Бакалавров:{0}", bachelor);

            // Print Students list
            Console.WriteLine("\nСписок всех студентов:\n");
            list.Print();

            // Print Courses Statistic 
            Console.WriteLine("\nСтатистика по курсам:");
            Dictionary<int, int> courses = CoursesStatistic(list, 18, 20);
            Console.WriteLine(PrintDictionary(courses));

            // Print students sorted by age
            Console.WriteLine("\nСписок всех студентов отсортированный по возрасту:\n");
            list.Sort(SortByAge);
            list.Print();

            // Print students sorted by course and age
            Console.WriteLine("\nСписок всех студентов отсортированный по курсу и возрасту:\n");
            list.Sort(SortByCourseAge);
            list.Print();

            Console.ReadLine();
        }
    }
}
