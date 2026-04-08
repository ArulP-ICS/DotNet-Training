using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program4
    {
        delegate int Calculator(int a, int b);
        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Subtract(int x, int y)
        {
            return x - y;
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }


        static void PerformOperation(Calculator calc, int a, int b)
        {
            int result = calc(a, b);
            Console.WriteLine(result);
        }
        static void Main()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Addition: ");
            PerformOperation(Add, num1, num2);

            Console.Write("Subtraction: ");
            PerformOperation(Subtract, num1, num2);

            Console.Write("Multiplication: ");
            PerformOperation(Multiply, num1, num2);
        }
    }
}
