using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program2
    {
        static void Main()
        {

            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            if (text.Length <= 1)
            {
                Console.WriteLine(text);
                return;
            }


            char[] chars = text.ToCharArray();

            char temp = chars[0];
            chars[0] = chars[chars.Length - 1];
            chars[chars.Length - 1] = temp;

            string result = new string(chars);
            Console.WriteLine(result);

        }
    }
}
