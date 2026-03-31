using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    internal class Program3
    {
        static void Main()
        {
            Console.Write("Enter Sales Number: ");
            int salesNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Number: ");
            int productNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Date of Sale: ");
            string dateOfSale = Console.ReadLine();

            
            SaleDetails sd = new SaleDetails(salesNo, productNo, price, qty, dateOfSale);

           
            SaleDetails.ShowData();

            Console.ReadKey();
        }
    }

    
    class SaleBase
    {
        protected static int salesNo;
        protected static int productNo;
        protected static double price;
        protected static int qty;
        protected static string dateOfSale;
        protected static double totalAmount;

        public SaleBase(int sNo, int pNo, double pr, int q, string date)
        {
            salesNo = sNo;
            productNo = pNo;
            price = pr;
            qty = q;
            dateOfSale = date;
        }
    }

    
    class SaleDetails : SaleBase
    {
        public SaleDetails(int sNo, int pNo, double pr, int q, string date)
            : base(sNo, pNo, pr, q, date)
        {
            Sales();
        }

        
        public static void Sales()
        {
            totalAmount = qty * price;
        }

        
        public static void ShowData()
        {
            Console.WriteLine("\n----- SALE DETAILS -----");
            Console.WriteLine("Sales No     : " + salesNo);
            Console.WriteLine("Product No   : " + productNo);
            Console.WriteLine("Price        : " + price);
            Console.WriteLine("Quantity     : " + qty);
            Console.WriteLine("Date of Sale : " + dateOfSale);
            Console.WriteLine("Total Amount : " + totalAmount);
        }
    }
}
