using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program3
    {

        static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new Exception("Number cannot be negative");
            }

            Console.WriteLine($"The number {number} is Valid ");
        }
        static void Main()
        {

            try
            {
                Console.Write("Enter an integer: ");
                int num = Convert.ToInt32(Console.ReadLine());

                CheckNumber(num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }


        }
    }
}
