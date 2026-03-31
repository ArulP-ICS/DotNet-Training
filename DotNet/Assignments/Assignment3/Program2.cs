using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment3
{
    internal class Program2
    {
        static void Main()
        {
            Console.Write("Enter Roll Number: ");
            int rollno = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string cls = Console.ReadLine();

            Console.Write("Enter Semester: ");
            int sem = int.Parse(Console.ReadLine());

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

           
            Student s = new Student(rollno, name, cls, sem, branch);

            s.DisplayData();   
            s.GetMarks();      
            s.DisplayResult(); 

            Console.ReadKey();
        }
    }

    
    class StudentBase
    {
        protected int rollno;
        protected string name;
        protected string cls;
        protected int sem;
        protected string branch;

        public StudentBase(int r, string n, string c, int s, string b)
        {
            rollno = r;
            name = n;
            cls = c;
            sem = s;
            branch = b;
        }

        public void DisplayData()
        {
            Console.WriteLine("\n----- STUDENT DETAILS -----");
            Console.WriteLine("Roll No  : " + rollno);
            Console.WriteLine("Name     : " + name);
            Console.WriteLine("Class    : " + cls);
            Console.WriteLine("Semester : " + sem);
            Console.WriteLine("Branch   : " + branch);
        }
    }

    
    class Student : StudentBase
    {
        int[] marks = new int[5];

        public Student(int r, string n, string c, int s, string b)
            : base(r, n, c, s, b)
        {
        }

        public void GetMarks()
        {
            Console.WriteLine("\nEnter marks of 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool failed = false;

            foreach (int m in marks)
            {
                if (m < 35)
                    failed = true;

                total += m;
            }

            double avg = total / 5.0;
            Console.WriteLine("\nAverage: " + avg);

            if (failed || avg < 50)
                Console.WriteLine("Result: FAILED");
            else
                Console.WriteLine("Result: PASSED");
        }
    }
}