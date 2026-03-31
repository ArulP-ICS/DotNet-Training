using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment3
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Account Type (Savings / Current): ");
            string accType = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Transaction Type (D = Deposit, W = Withdraw): ");
            char tType = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            
            Accounts acc = new Accounts(accNo, name, accType, balance, tType, amount);

            acc.ShowData();

            Console.ReadKey();
        }
    }

  
    class Account
    {
        protected int accountNo;
        protected string customerName;
        protected string accountType;
        protected double balance;

        public Account(int accNo, string name, string accType, double bal)
        {
            accountNo = accNo;
            customerName = name;
            accountType = accType;
            balance = bal;
        }

        public void Credit(double amount)
        {
            balance += amount;
        }

        public void Debit(double amount)
        {
            if (amount <= balance)
                balance -= amount;
            else
                Console.WriteLine("Insufficient Balance");
        }
    }

    
    class Accounts : Account
    {
        char transactionType;
        double amount;

        public Accounts(int accNo, string name, string accType, double bal,
                        char tType, double amt)
            : base(accNo, name, accType, bal)
        {
            transactionType = tType;
            amount = amt;
            UpdateBalance();
        }

        public void UpdateBalance()
        {
            if (transactionType == 'D')
                Credit(amount);
            else if (transactionType == 'W')
                Debit(amount);
            else
                Console.WriteLine("Invalid Transaction Type");
        }

        public void ShowData()
        {
            Console.WriteLine("\n----- ACCOUNT DETAILS -----");
            Console.WriteLine("Account No     : " + accountNo);
            Console.WriteLine("Customer Name  : " + customerName);
            Console.WriteLine("Account Type   : " + accountType);
            Console.WriteLine("Balance        : " + balance);
        }
    }
}