using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a digit : ");
            int digit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("{0} {0} {0} {0}",digit);
            Console.WriteLine("{0}{0}{0}{0}", digit);
            Console.WriteLine("{0} {0} {0} {0}", digit);
            Console.WriteLine("{0}{0}{0}{0}", digit);
            Console.ReadKey();

        }
    }
}
