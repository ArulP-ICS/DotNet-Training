using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Arrays2
    {
        static void Main()
        {
            
            Console.Write("Enter the size of the array : ");

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for(int i=0;i<n;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            TotalMark(arr);
            AverageMark(arr);
            MinimumMark(arr);
            MaximumMark(arr);
            AscendingOrderMarks(arr);
            DescendingOrderMarks(arr);
            


        }

        public static void TotalMark(int[] arr)
        {
            Console.WriteLine("a.Total");
            
            int total = 0;
            foreach(int i in arr)
            {
                total += i;
            }
            Console.WriteLine($"The total mark is {total}");
            

        }

        public static void AverageMark(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("b.Average");
            int total = 0;
            foreach(int i in arr)
            {
                total += i;
            }

            double avg = (double) total / arr.Length;
            Console.WriteLine($"The average mark is : {avg}");
            
        }

        public static void MinimumMark(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("c.Minimum Marks");

            int minmark = arr[0];

            foreach(int mark in arr)
            {
                if(minmark > mark)
                {
                    minmark = mark;
                }
            }
            Console.WriteLine($"The minimum mark is {minmark}");
            
        }

        public static void MaximumMark(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("d.Maximum Marks");

            int MaxMark = arr[0];
            foreach(int mark in arr)
            {
                if(MaxMark < mark)
                {
                    MaxMark = mark;
                }
            }
            Console.WriteLine($"The maximum mark is {MaxMark}");
            
        }


        public static void AscendingOrderMarks(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("e.Display marks in ascending order ");
            
            Console.WriteLine("Marks in ascending order : ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            foreach(int mark in arr)
            {
                Console.Write(mark + " ");
               
                
            }
            
        }


        public static void DescendingOrderMarks(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("f.Display marks in descending order ");
           
            Console.WriteLine("Marks in descending order : ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            foreach (int mark in arr)
            {
                Console.Write(mark + " ");
                
                
            }
            


        }



    }
}
