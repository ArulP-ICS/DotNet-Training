using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    internal class Program2
    {

        struct DateOfBirth
        {
            public int Day;
            public int Month;
            public int Year;
        }
        struct Employee
        {
            public string Name;
            public DateOfBirth DOB;
        }

        static void Main(string[] args)
        {
            Employee[] emp = new Employee[2];

            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine("\nEnter details for employee " + (i + 1));

                Console.Write("Name of the employee: ");
                emp[i].Name = Console.ReadLine();

                Console.Write("Input day of the birth: ");
                emp[i].DOB.Day = Convert.ToInt32(Console.ReadLine());


                Console.Write("Input month of the birth: ");
                emp[i].DOB.Month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Input year for the birth: ");
                emp[i].DOB.Year = Convert.ToInt32(Console.ReadLine());
            }


            Console.WriteLine("\nStored Employee Details:");
            Console.WriteLine("---------------------------");


            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Employee Name: " + emp[i].Name);
                Console.WriteLine("Date of Birth: " + emp[i].DOB.Day + "/" + emp[i].DOB.Month + "/" + emp[i].DOB.Year);
                Console.WriteLine();
            }

            Console.ReadKey();


        }


    }
}
