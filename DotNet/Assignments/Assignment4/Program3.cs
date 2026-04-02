using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program3
    {
        static void Main()
        {
            Stack stack = new Stack();

            Console.Write("Enter number of elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter stack elements:");
            for (int i = 0; i < n; i++)
            {
                stack.Push(Convert.ToInt32(Console.ReadLine()));
            }


            Stack sortedStack = SortDescending(stack);

            Console.WriteLine("Stack elements in descending order:");


            while (sortedStack.Count > 0)
            {
                Console.Write(sortedStack.Pop() + " ");
            }

        }

        static Stack SortDescending(Stack stack)
        {
            Stack tempStack = new Stack();

            while (stack.Count > 0)
            {
                int temp = (int)stack.Pop();

                while (tempStack.Count > 0 && (int)tempStack.Peek() < temp)
                {
                    stack.Push(tempStack.Pop());
                }

                tempStack.Push(temp);
            }

            return tempStack;

        }
    }
}
