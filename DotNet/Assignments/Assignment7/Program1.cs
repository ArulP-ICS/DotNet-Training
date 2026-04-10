using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Program1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter numbers separated by space:");
            string input = Console.ReadLine();

            string[] values = input.Split(' ');

            PrintNumbersWithSquareGreaterThan20(values);

            Console.ReadLine();

        }
        static void PrintNumbersWithSquareGreaterThan20(string[] values)
        {
            foreach (string v in values)
            {
                int num = int.Parse(v);
                int square = num * num;

                if (square > 20)
                {
                    Console.WriteLine(num + " - " + square);
                }
            }
        }

    }
}
