using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Program2
    {

        class ScholarshipNotEligibleException : Exception
        {
            public ScholarshipNotEligibleException(string message) : base(message)
            {
            }
        }
        class Scholarship
        {
            public double Merit(int marks, double fees)
            {
                double scholarshipAmount;

                if (marks >= 70 && marks <= 80)
                {
                    scholarshipAmount = fees * 0.20;
                }
                else if (marks > 80 && marks <= 90)
                {
                    scholarshipAmount = fees * 0.30;
                }
                else if (marks > 90)
                {
                    scholarshipAmount = fees * 0.50;
                }
                else
                {
                    throw new ScholarshipNotEligibleException(
                        "Marks below 70. Student is not eligible for scholarship."
                    );
                }

                return scholarshipAmount;
            }
        }



        static void Main()
        {

            try
            {
                Console.Write("Enter student marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter total fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());

                Scholarship scholarship = new Scholarship();
                double amount = scholarship.Merit(marks, fees);

                Console.WriteLine("Scholarship Amount: " + amount);
            }


            catch (ScholarshipNotEligibleException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Error: Please enter valid numbers.");
            }
            finally
            {
                Console.WriteLine("Scholarship evaluation completed.");
            }
        }
    }
}
