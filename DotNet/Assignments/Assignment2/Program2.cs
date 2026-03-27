using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program2
    {
        static void Main()
        {
            Console.Write("Enter day number : ");

            int day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    break;

                default:
                    Console.WriteLine("Invalid day number");
                    break;

            }
            Console.ReadKey();
            
        }
    }
}
