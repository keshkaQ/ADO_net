using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_6_LINQ
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{FirstName,15} {LastName,15} {City,15} {Age,15}";
        }
    }
    public class Program
    {
        public static void Func_student_create(List<Student> students)
        {
            Random rnd = new Random();
            string[] city = { "c2", "c4", "c5", "c10", "c1", "c123", "c45" };
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student { FirstName = "FirstName" + i, LastName = "LastName" + i, City = city[rnd.Next(0, city.Length - 1)], Age = rnd.Next(16, 20) });
            }
        }
        public static void Find_linq_student(List<Student> students)
        {
            var res = from s in students
                      where s.Age >= 18
                      orderby s.Age
                      select new {s.FirstName, s.LastName,s.City, s.Age };
            Console.WriteLine($"{"Имя",15} {"Фамилия",15} {"Город",15} {"Возраст",15}");
            foreach (var s in res)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            var students = new List<Student>();
            Func_student_create(students);
            Console.WriteLine($"{"Имя",15} {"Фамилия",15} {"Город",15} {"Возраст",15}");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("---------------------------------");
            Find_linq_student(students);

        }
    }
}
