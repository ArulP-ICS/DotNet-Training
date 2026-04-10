using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelLibrary;

namespace Assignment7
{
    class Program4
    {
        const int TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter Passenger Name:");
            string name = Console.ReadLine();

            Console.Write("Enter Passenger Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            
            TravelConcession tc = new TravelConcession();

            
            string result = tc.CalculateConcession(age, TotalFare);

            Console.WriteLine("\nPassenger Name: " + name);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}