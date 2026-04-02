using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assessment1
{
    internal class Program1
    {

        public class Employee
        {
            public int Id;
            public string Name;
            public string Department;
            public double Salary;
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    AddEmployee(employees);
                }
                else if (choice == 2)
                {
                    ViewEmployees(employees);
                }
                else if (choice == 3)
                {
                    SearchEmployee(employees);
                }
                else if (choice == 4)
                {
                    UpdateEmployee(employees);
                }
                else if (choice == 5)
                {
                    DeleteEmployee(employees);
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Program exited.");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            } 

            Console.ReadKey();
        }

       
        static void AddEmployee(List<Employee> employees)
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();

            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee added successfully.");
        }

        
        static void ViewEmployees(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(
                    "ID: " + employees[i].Id +
                    ", Name: " + employees[i].Name +
                    ", Department: " + employees[i].Department +
                    ", Salary: " + employees[i].Salary
                );
            }
        }

       
        static void SearchEmployee(List<Employee> employees)
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.WriteLine(
                        "ID: " + employees[i].Id +
                        ", Name: " + employees[i].Name +
                        ", Department: " + employees[i].Department +
                        ", Salary: " + employees[i].Salary
                    );
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
        }

       
        static void UpdateEmployee(List<Employee> employees)
        {
            Console.Write("Enter ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    Console.Write("Enter new Name: ");
                    employees[i].Name = Console.ReadLine();

                    Console.Write("Enter new Department: ");
                    employees[i].Department = Console.ReadLine();

                    Console.Write("Enter new Salary: ");
                    employees[i].Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Employee updated.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
        }

       
        static void DeleteEmployee(List<Employee> employees)
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.RemoveAt(i);
                    Console.WriteLine("Employee deleted.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }

    
}