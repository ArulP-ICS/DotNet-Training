using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace Assessment1
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Type { get; set; }
    }

    internal class Problem1
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            InsertEmployee();
            ShowEmployees();

            Console.ReadLine();
        }

        
        static void InsertEmployee()
        {
            try
            {
                Employee emp = new Employee();

                Console.Write("Enter Employee Name : ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter Salary : ");
                emp.Salary = Convert.ToDecimal(Console.ReadLine());

               
                if (emp.Salary < 25000)
                {
                    Console.WriteLine("Salary must be greater than or equal to 25000");
                    return;
                }

                Console.Write("Enter Employee Type (F/P) : ");
                emp.Type = Console.ReadLine().ToUpper();

               
                if (emp.Type != "F" && emp.Type != "P")
                {
                    Console.WriteLine("Type must be F or P");
                    return;
                }

                conn = GetConnection();

                
                cmd = new SqlCommand("AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.AddWithValue("@EmpName", emp.Name);
                cmd.Parameters.AddWithValue("@Empsal", emp.Salary);
                cmd.Parameters.AddWithValue("@Emptype", emp.Type);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("\nRecord Inserted Successfully...");
                }
                else
                {
                    Console.WriteLine("\nCould not Insert Record...");
                }

                conn.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Salary Format");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        static void ShowEmployees()
        {
            try
            {
                conn = GetConnection();

                cmd = new SqlCommand("SELECT * FROM Employee_Details", conn);

                dataReader = cmd.ExecuteReader();

                Console.WriteLine("\nEmployee Details");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("EmpNo\tEmpName\t\tSalary\t\tType");
                Console.WriteLine("---------------------------------------------");

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["Empno"] + "\t" +
                        dataReader["EmpName"] + "\t\t" +
                        dataReader["Empsal"] + "\t\t" +
                        dataReader["Emptype"]);
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        static SqlConnection GetConnection()
        {
            conn = new SqlConnection(
                "Data Source=ICS-LT-CFW37V3\\SQLEXPRESS;" +
                "Initial Catalog=Employeemanagement;" +
                "Integrated Security=True");

            conn.Open();

            return conn;
        }
    }
}