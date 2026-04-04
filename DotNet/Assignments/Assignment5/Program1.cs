using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Program1
    {

        class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException(string message) : base(message)
            {

            }
        }

        class BankAccount
        {
            private double balance;
            public BankAccount(double initialBalance)
            {
                balance = initialBalance;
            }
            public void Deposit(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be greater than zero.");
                }

                balance += amount;
                Console.WriteLine("Deposit Successful.");
            }

            public void Withdraw(double amount)
            {

                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");
                }


                if (amount > balance)
                {
                    throw new InsufficientBalanceException(
                        "Withdrawal failed: Insufficient balance."
                    );
                }

                balance -= amount;
                Console.WriteLine("Withdrawal Successful.");

            }

            public void ShowBalance()
            {
                Console.WriteLine("Current Balance: " + balance);
            }

        }

        static void Main(string[] args)
        {
            try
            {

                Console.Write("Enter initial balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                BankAccount account = new BankAccount(initialBalance);

                Console.Write("Enter amount to deposit: ");
                double depositAmount = Convert.ToDouble(Console.ReadLine());
                account.Deposit(depositAmount);
                account.ShowBalance();

                Console.Write("Enter amount to withdraw: ");
                double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(withdrawAmount);
                account.ShowBalance();

            }


            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Error: Please enter a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Error: " + ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Completed.");
            }
        }
    }
}
