using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            checkequalnumber();
            checkpositiveornegative();
            MathOperations();
            PrintMultiplicationTable();
            SumOrTriple();

            Console.ReadKey();
        }

        static void checkequalnumber()
        {
            Console.WriteLine("1.Check whether two integers are equal");

            Console.Write("Input 1st number: ");

            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input 2nd number: ");

            int num2 = Convert.ToInt32(Console.ReadLine());

            if(num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal");
            }

            Console.WriteLine("--------------------------------------------------");
        }

        static void checkpositiveornegative()
        {
            Console.WriteLine("2.Check whether a number is positive or negative");

            Console.Write("Enter the number : ");

            int num = Convert.ToInt32(Console.ReadLine());

            if(num > 0)
            {
                Console.WriteLine($"{num} is a positive number");
            }

            else if( num == 0)
            {
                Console.WriteLine("the number is zero");
            }
            else
            {
                Console.WriteLine($"{num} is a negative number");
            }

            Console.WriteLine("--------------------------------------------------");
        }

        static void MathOperations()
        {
            Console.WriteLine("3.C# math operations are performed using arithmetic operators like +, -, *, /");
            Console.Write("Input first number : ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input secod number : ");
            int num2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");

            if (num2 != 0)
                Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
            else
                Console.WriteLine("Division by zero is not allowed");
            Console.WriteLine("--------------------------------------------------");

        }

        static void PrintMultiplicationTable()
        {
            Console.WriteLine("4.Multiplication Table Program");
            Console.Write("Enter the number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{number} * {i} = {number * i}");
            }

            Console.WriteLine("--------------------------------------------------");
        }


        static void SumOrTriple()
        {
            Console.WriteLine("5.Sum or Triple Sum");
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;

            if (num1 == num2)
                Console.WriteLine("Result: " + (sum * 3));
            else
                Console.WriteLine("Result: " + sum);

            Console.WriteLine("--------------------------------------------------");
        }




    }
}
