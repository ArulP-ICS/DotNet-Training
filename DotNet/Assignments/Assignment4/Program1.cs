using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program1
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            Console.Write("Enter position: ");
            int position = Convert.ToInt32(Console.ReadLine());

            string result = text.Remove(position, 1);
            Console.WriteLine(result);

        }
    }
}
