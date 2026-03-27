using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Arrays1
    {
        static void Main()
        {
            ArrayAverage();
            MinMaxValue();


            Console.ReadKey();
        }

        public static void ArrayAverage()
        {
            Console.WriteLine("a.Average value of array elements");
            Console.WriteLine();

            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("Array size must be greater than zero.");
                return;
            }

            int[] arr = new int[n];

            Console.WriteLine("Enter the array elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }

            double avg = (double)sum / n;
            Console.WriteLine("The average value is: " + avg);
            Console.WriteLine("=============================================");
        }

        public static void MinMaxValue()
        {
            Console.WriteLine("b.Minimum and Maximum value in an array");
            Console.WriteLine();

            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter the array elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int min = arr[0];
            int max = arr[0];

            foreach (int value in arr)
            {
                if (value < min)
                {
                    min = value;
                }

                if (value > max)
                {
                    max = value;
                }
            }

            Console.WriteLine("Minimum value is: " + min);
            Console.WriteLine("Maximum value is: " + max);
        }


    }
}
