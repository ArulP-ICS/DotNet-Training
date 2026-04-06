using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assignment6
{
    internal class Program3
    {
        static void Main()
        {

            string filePath = @"C:/Users/arulp/ICS Training 2026/DotNet/Assignments/Assignment6/sample.txt";
            int lineCount = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Console.WriteLine("Number of lines in the file: " + lineCount);
            Console.ReadKey();
        }
    }
}
