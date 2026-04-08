using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program2
    {
        class Products
        {
            public int ProductId;
            public string ProductName;
            public double Price;
        }
        static void Main()
        {
            Products[] products = new Products[10];

            for (int i = 0; i < 10; i++)
            {

                products[i] = new Products();

                Console.WriteLine("Enter details for Product " + (i + 1));

                Console.Write("Product ID: ");
                products[i].ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Product Name: ");
                products[i].ProductName = Console.ReadLine();


                Console.Write("Price: ");
                products[i].Price = Convert.ToDouble(Console.ReadLine());
            }


            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (products[i].Price > products[j].Price)
                    {
                        Products temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
            Console.WriteLine("\nProducts sorted by Price:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(products[i].ProductId + " " + products[i].ProductName + " " + products[i].Price);
               
            }
        }
    }
}
