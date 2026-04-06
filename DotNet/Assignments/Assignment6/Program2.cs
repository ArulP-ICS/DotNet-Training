using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    internal class Program2
    {
        static void Main()
        {

            string fileName = @"C:/Users/arulp/ICS Training 2026/DotNet/Assignments/Assignment6/sample.txt";

            Console.Write("Enter number of lines to write to the file: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] data = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter line " + (i + 1) + ": ");
                data[i] = Console.ReadLine();
            }

            File.WriteAllLines(fileName, data);
            Console.WriteLine("\nData written to file successfully.\n");

            
            Console.WriteLine("Reading data from file:\n");
            string[] readData = File.ReadAllLines(fileName);


            foreach (string line in readData)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();

        }
    }
}
