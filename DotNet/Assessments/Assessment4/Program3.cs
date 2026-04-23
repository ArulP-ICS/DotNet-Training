using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program3
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID=1001, FirstName="Malcolm", 
                    LastName="Daruwalla", Title="Manager", DOB=new DateTime(1984,11,16), 
                    DOJ=new DateTime(2011,6,8), City="Mumbai" },

                new Employee { EmployeeID=1002, FirstName="Asdin", 
                    LastName="Dhalla", Title="AsstManager", DOB=new DateTime(1984,8,20), 
                    DOJ=new DateTime(2012,7,7), City="Mumbai" },

                new Employee { EmployeeID=1003, FirstName="Madhavi", 
                    LastName="Oza", Title="Consultant", DOB=new DateTime(1987,11,14),
                    DOJ=new DateTime(2015,4,12), City="Pune" },

                new Employee { EmployeeID=1004, FirstName="Saba", 
                    LastName="Shaikh", Title="SE", DOB=new DateTime(1990,6,3),
                    DOJ=new DateTime(2016,2,2), City="Pune" },

                new Employee { EmployeeID=1005, FirstName="Nazia",
                    LastName="Shaikh", Title="SE", DOB=new DateTime(1991,3,8), 
                    DOJ=new DateTime(2016,2,2), City="Mumbai" },

                new Employee { EmployeeID=1006, FirstName="Amit",
                    LastName="Pathak", Title="Consultant", DOB=new DateTime(1989,11,7),
                    DOJ=new DateTime(2014,8,8), City="Chennai" },

                new Employee { EmployeeID=1007, FirstName="Vijay",
                    LastName="Natrajan", Title="Consultant", DOB=new DateTime(1989,12,2),
                    DOJ=new DateTime(2015,6,1), City="Mumbai" },

                new Employee { EmployeeID=1008, FirstName="Rahul", 
                    LastName="Dubey", Title="Associate", DOB=new DateTime(1993,11,11), 
                    DOJ=new DateTime(2014,11,6), City="Chennai" },

                new Employee { EmployeeID=1009, FirstName="Suresh", 
                    LastName="Mistry", Title="Associate", DOB=new DateTime(1992,8,12), 
                    DOJ=new DateTime(2014,12,3), City="Chennai" },

                new Employee { EmployeeID=1010, FirstName="Sumit", 
                    LastName="Shah", Title="Manager", DOB=new DateTime(1991,4,12), 
                    DOJ=new DateTime(2016,1,2), City="Pune" }
            };


            Console.WriteLine("===== Employee LINQ Menu =====");
            Console.WriteLine("1. Display All Employees");
            Console.WriteLine("2. Employees NOT from Mumbai");
            Console.WriteLine("3. Employees with Title AsstManager");
            Console.WriteLine("4. Employees whose Last Name starts with 'S'");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {

                case 1:
                    Console.WriteLine("\nAll Employees:");
                    foreach (var e in empList)
                        Console.WriteLine($"EmployeeID : {e.EmployeeID}  FirstName : {e.FirstName}  LastName : {e.LastName} Title :  {e.Title} City :  {e.City}");
                    break;


                case 2:
                    Console.WriteLine("\nEmployees NOT from Mumbai:");
                    foreach (var e in empList.Where(e => e.City != "Mumbai"))
                        Console.WriteLine($" FirstName : {e.FirstName} LastName :  {e.LastName} - City :  {e.City}");
                    break;


                case 3:
                    Console.WriteLine("\nEmployees with Title AsstManager:");
                    foreach (var e in empList.Where(e => e.Title == "AsstManager"))
                        Console.WriteLine($" FirstName : {e.FirstName} LastName :  {e.LastName}");
                    break;

                case 4:
                    Console.WriteLine("\nEmployees whose Last Name starts with 'S':");
                    foreach (var e in empList.Where(e => e.LastName.StartsWith("S")))
                        Console.WriteLine($" FirstName : {e.FirstName} LastName :  {e.LastName}");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }


            Console.ReadLine();
        }
    }
}
