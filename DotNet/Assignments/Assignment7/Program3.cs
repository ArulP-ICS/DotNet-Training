using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assignment7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
    }

    class Program3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Enter number of employees:");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}");

                Console.Write("EmpId: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("EmpName: ");
                string name = Console.ReadLine();

                Console.Write("EmpCity: ");
                string city = Console.ReadLine();

                Console.Write("EmpSalary: ");
                int salary = int.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = id,
                    EmpName = name,
                    EmpCity = city,
                    EmpSalary = salary
                });
            }

           
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("a - Display All Employees");
            Console.WriteLine("b - Salary Greater Than 45000");
            Console.WriteLine("c - Employees from Bangalore");
            Console.WriteLine("d - Sort Employees by Name (Ascending)");

            Console.Write("Enter your choice  : ");
            char choice = char.ToLower(Console.ReadLine()[0]);

            switch (choice)
            {
                case 'a':
                    Console.WriteLine("\n---- All Employees ----");
                    DisplayEmployees(employees);
                    break;

                case 'b':
                    Console.WriteLine("\n---- Salary Greater Than 45000 ----");
                    DisplayEmployees(
                        employees.Where(e => e.EmpSalary > 45000));
                    break;

                case 'c':
                    Console.WriteLine("\n---- Employees from Bangalore ----");
                    DisplayEmployees(
                        employees.Where(e =>
                            e.EmpCity.Equals("Bangalore",
                            StringComparison.OrdinalIgnoreCase)));
                    break;

                case 'd':
                    Console.WriteLine("\n---- Employees Sorted by Name ----");
                    DisplayEmployees(
                        employees.OrderBy(e => e.EmpName));
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.ReadLine();
        }

        static void DisplayEmployees(IEnumerable<Employee> list)
        {
            foreach (var emp in list)
            {
                Console.WriteLine(
                    $"Id: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
    }
}