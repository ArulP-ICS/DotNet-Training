using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assessment3
{
    class Program2
    {
        static void Main()
        {
            string filePath =
@"C:\Users\arulp\ICS Training 2026\DotNet\Assessments\Assessment3\Outputs\Program 2 output\Assessment3File.txt";

            Console.Write("Enter text to append to the file: ");
            string text = Console.ReadLine();

            // Append mode = true (creates file if not exists)
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }

            Console.WriteLine("Text successfully appended to the file.");
            Console.ReadLine();
        }
    }
}
