using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Assessment1
{
    internal class Problem2
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            UpdateSalary();
            Console.ReadLine();
        }

       
        static void UpdateSalary()
        {
            try
            {
                conn = GetConnection();

                Console.Write("Enter Employee Number : ");
                int empno = Convert.ToInt32(Console.ReadLine());

               
                cmd = new SqlCommand("UpdateSalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Empno", empno);

               
                SqlParameter outParam =
                    new SqlParameter("@UpdatedSalary", SqlDbType.Decimal);

                outParam.Direction = ParameterDirection.Output;
                outParam.Precision = 10;
                outParam.Scale = 2;

                cmd.Parameters.Add(outParam);

                
                cmd.ExecuteNonQuery();

                
                if (outParam.Value != DBNull.Value)
                {
                    decimal updatedSalary =
                        Convert.ToDecimal(outParam.Value);

                    Console.WriteLine("\nUpdated Salary : " + updatedSalary);

                   
                    DisplayEmployee(empno);
                }
                else
                {
                    Console.WriteLine("\nEmployee Record Not Found");
                }

                conn.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Employee Number");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

       
        static void DisplayEmployee(int empno)
        {
            try
            {
                conn = GetConnection();

                cmd = new SqlCommand(
                    "SELECT * FROM Employee_Details WHERE Empno=@Empno",
                    conn);

                cmd.Parameters.AddWithValue("@Empno", empno);

                dataReader = cmd.ExecuteReader();

                bool status = dataReader.HasRows;

                if (status)
                {
                    Console.WriteLine("\nUpdated Employee Record");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("EmpNo\tEmpName\t\tSalary\t\tType");
                    Console.WriteLine("--------------------------------------------");

                    while (dataReader.Read())
                    {
                        Console.WriteLine(
                            dataReader["Empno"] + "\t" +
                            dataReader["EmpName"] + "\t\t" +
                            dataReader["Empsal"] + "\t\t" +
                            dataReader["Emptype"]);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
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