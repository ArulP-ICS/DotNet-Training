using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrainReservationSystem.Data;

namespace TrainReservationSystem.Repositories
{
    public class TrainRepository
    {
        DBConnection db = new DBConnection();

        public void ViewTrains()
        {
            SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Trains WHERE IsDeleted = 0";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n==============================================================================================================");

            Console.WriteLine(
                "No\tTrain Name\tFrom\tTo\t2AC(S)\t2AC(P)\t3AC(S)\t3AC(P)\tSL(S)\tSL(P)");

            Console.WriteLine("==============================================================================================================");

            while (reader.Read())
            {
                Console.WriteLine(
                    reader["TrainNo"] + "\t" +
                    reader["TrainName"] + "\t" +
                    reader["FromStation"] + "\t" +
                    reader["ToStation"] + "     \t" +
                    reader["Seats2AC"] + "    \t" +
                    reader["Price2AC"] + "   \t" +
                    reader["Seats3AC"] + "    \t" +
                    reader["Price3AC"] + "    \t" +
                    reader["SleeperSeats"] + "    \t" +
                    reader["SleeperPrice"]
                );
            }

            Console.WriteLine("==============================================================================================================");

            con.Close();
        }

        public void AddTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Train Name: ");
            string name = Console.ReadLine();

            Console.Write("From Station: ");
            string from = Console.ReadLine();

            Console.Write("To Station: ");
            string to = Console.ReadLine();

            Console.WriteLine("\n===== 2AC DETAILS =====");

            Console.Write("2AC Seats: ");
            int seats2AC = Convert.ToInt32(Console.ReadLine());

            Console.Write("2AC Price: ");
            decimal price2AC = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\n===== 3AC DETAILS =====");

            Console.Write("3AC Seats: ");
            int seats3AC = Convert.ToInt32(Console.ReadLine());

            Console.Write("3AC Price: ");
            decimal price3AC = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\n===== SLEEPER DETAILS =====");

            Console.Write("Sleeper Seats: ");
            int sleeperSeats = Convert.ToInt32(Console.ReadLine());

            Console.Write("Sleeper Price: ");
            decimal sleeperPrice = Convert.ToDecimal(Console.ReadLine());

            string query =
            @"INSERT INTO Trains
            VALUES
            (
                @no,
                @name,
                @from,
                @to,

                @s2ac,
                @p2ac,

                @s3ac,
                @p3ac,

                @ss,
                @sp,

                0
            )";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@no", trainNo);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);

            cmd.Parameters.AddWithValue("@s2ac", seats2AC);
            cmd.Parameters.AddWithValue("@p2ac", price2AC);

            cmd.Parameters.AddWithValue("@s3ac", seats3AC);
            cmd.Parameters.AddWithValue("@p3ac", price3AC);

            cmd.Parameters.AddWithValue("@ss", sleeperSeats);
            cmd.Parameters.AddWithValue("@sp", sleeperPrice);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine("\nTrain Added Successfully");
        }

        public void UpdateTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Enter Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n1. 2AC");
            Console.WriteLine("2. 3AC");
            Console.WriteLine("3. Sleeper");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string seatColumn = "";
            string priceColumn = "";

            switch (choice)
            {
                case 1:
                    seatColumn = "Seats2AC";
                    priceColumn = "Price2AC";
                    break;

                case 2:
                    seatColumn = "Seats3AC";
                    priceColumn = "Price3AC";
                    break;

                case 3:
                    seatColumn = "SleeperSeats";
                    priceColumn = "SleeperPrice";
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    return;
            }

            Console.Write("New Seat Count: ");
            int seats = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            string query = $"UPDATE Trains SET {seatColumn}=@s, {priceColumn}=@p WHERE TrainNo=@no";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@s", seats);
            cmd.Parameters.AddWithValue("@p", price);
            cmd.Parameters.AddWithValue("@no", trainNo);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            con.Close();

            if (rows > 0)
                Console.WriteLine("Train Updated Successfully");
            else
                Console.WriteLine("Train Not Found");
        }

        public void SoftDeleteTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Enter Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            con.Open();

            string checkQuery = "SELECT COUNT(*) FROM Bookings WHERE TrainNo=@no";

            SqlCommand checkCmd = new SqlCommand(checkQuery, con);

            checkCmd.Parameters.AddWithValue("@no", trainNo);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                Console.WriteLine("Cannot Delete. Booking Exists.");

                con.Close();
                return;
            }

            string query = "UPDATE Trains SET IsDeleted = 1 WHERE TrainNo=@no";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@no", trainNo);

            int rows = cmd.ExecuteNonQuery();

            con.Close();

            if (rows > 0)
                Console.WriteLine("Train Deleted Successfully");
            else
                Console.WriteLine("Train Not Found");
        }
    }
}
