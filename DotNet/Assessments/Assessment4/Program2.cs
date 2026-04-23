using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assessment4.Factory;
using Assessment4.Reports;

namespace Assessment4
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Report Type:");
            Console.WriteLine("1. Chart");
            Console.WriteLine("2. Tabular");
            Console.WriteLine("3. Summary");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            IReport report = ReportFactory.GetReport(choice);

            if (report != null)
            {
                report.Generate();
            }
            else
            {
                Console.WriteLine("Invalid report type selected.");
            }

            Console.ReadLine();
        }
    }
}