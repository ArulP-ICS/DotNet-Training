using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter words separated by commas:");
            string input = Console.ReadLine();

            string[] words = input.Split(',').Select(w => w.Trim()).ToArray();

            var result = words.Where(w => w.StartsWith("a") && w.EndsWith("m"));

            Console.WriteLine("Result:");

            foreach (string word in result)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }
    }
}
