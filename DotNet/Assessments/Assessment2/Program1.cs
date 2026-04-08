using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program1
    {

        abstract class Student
        {
            public string Name { get; set; }
            public int StudentId { get; set; }
            public double Grade { get; set; }

            public abstract bool IsPassed(double grade);
        }


        class Undergraduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 70.0;
            }
        }


        class Graduate : Student
        {
            public override bool IsPassed(double grade)
            {
                return grade > 80.0;
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Select Student Type:");
            Console.WriteLine("1. Undergraduate");
            Console.WriteLine("2. Graduate");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());


            Student student;

            if (choice == 1)
            {
                student = new Undergraduate();
            }
            else
            {
                student = new Graduate();
            }


            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            student.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade: ");
            student.Grade = double.Parse(Console.ReadLine());


            bool result = student.IsPassed(student.Grade);

            Console.WriteLine("\n--- Student Result ---");
            Console.WriteLine($"Name      : {student.Name}");
            Console.WriteLine($"Student ID: {student.StudentId}");
            Console.WriteLine($"Grade     : {student.Grade}");
            Console.WriteLine($"Passed : {student.IsPassed(student.Grade)}");
        }
    }
}
