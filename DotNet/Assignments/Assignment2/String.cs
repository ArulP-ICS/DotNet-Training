using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class String
    {
        static void Main()
        {
            LengthOfString();
            StringReverse();
            CompareTwoStrings();

        }
        public static void LengthOfString()
        {
            Console.WriteLine("1. Display the length of the string ");
            Console.WriteLine();

            Console.Write("Enter the String : ");

            string str = Console.ReadLine();

            Console.WriteLine($"Length of the string is  : {str.Length}");

        }

        public static void StringReverse()
        {
            Console.WriteLine();
            Console.WriteLine("2.Display the reversed string");
            Console.WriteLine();
            Console.Write("Enter the string: ");
            string str = Console.ReadLine();

            char[] chars = str.ToCharArray(); 
            Array.Reverse(chars);             
            string reversed = new string(chars);

            Console.WriteLine("Reversed string: " + reversed);
        }

        public static void CompareTwoStrings()
        {
            Console.WriteLine();
            Console.WriteLine("3.Compare the two strings are equal or not");
            Console.WriteLine();
            Console.Write("Enter the first string : ");
            string str1 = Console.ReadLine();

            Console.Write("Enter the second string : ");
            string str2 = Console.ReadLine();

            if(str1.Equals(str2))
            {
                Console.WriteLine($"{str1} and {str2} are equal");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are not equal");
            }
        }
    }
}
