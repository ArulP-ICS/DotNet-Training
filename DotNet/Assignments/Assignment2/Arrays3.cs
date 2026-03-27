using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Arrays3
    {
        static void Main()
        {
            CopyArray();
        }
        static void CopyArray()
        {
            Console.Write("Enter the size of the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
                arr2[i] = arr1[i];   
            }

            Console.WriteLine("Copied array elements:");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.WriteLine(arr2[i] + " ");
            }
        }

    }
}
