using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TrainReservationSystem.Data;

namespace TrainReservationSystem.Repositories
{
    public class BookingRepository
    {
        DBConnection db = new DBConnection();

        public void BookTicket()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Train No: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nChoose Class");
            Console.WriteLine("1. 2AC");
            Console.WriteLine("2. 3AC");
            Console.WriteLine("3. Sleeper");

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string travelClass = "";
            string seatColumn = "";
            string priceColumn = "";

            switch (choice)
            {
                case 1:
                    travelClass = "2AC";
                    seatColumn = "Seats2AC";
                    priceColumn = "Price2AC";
                    break;

                case 2:
                    travelClass = "3AC";
                    seatColumn = "Seats3AC";
                    priceColumn = "Price3AC";
                    break;

                case 3:
                    travelClass = "Sleeper";
                    seatColumn = "SleeperSeats";
                    priceColumn = "SleeperPrice";
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    return;
            }

            Console.Write("Travel Date (dd-MM-yyyy): ");

            DateTime travelDate;

            while (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd-MM-yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out travelDate))
            {
                Console.WriteLine("Invalid Date Format");
                Console.Write("Enter Again (dd-MM-yyyy): ");
            }

            Console.Write("Passenger Count (Max 3): ");

            int count = Convert.ToInt32(Console.ReadLine());

            if (count > 3)
            {
                Console.WriteLine("Maximum 3 Passengers Allowed");
                return;
            }

            con.Open();

            string query = $"SELECT {seatColumn}, {priceColumn} FROM Trains WHERE TrainNo=@no";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@no", trainNo);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                Console.WriteLine("Train Not Found");

                con.Close();
                return;
            }

            int availableSeats = Convert.ToInt32(reader[seatColumn]);

            decimal ticketPrice = Convert.ToDecimal(reader[priceColumn]);

            reader.Close();

            if (availableSeats < count)
            {
                Console.WriteLine("Seats Not Available");

                con.Close();
                return;
            }

            decimal amount = ticketPrice * count;

            string insertBooking =
            @"INSERT INTO Bookings
            VALUES
            (
                @bdate,
                @tdate,
                @no,
                @class,
                @count,
                @amount
            );

            SELECT SCOPE_IDENTITY();";

            SqlCommand bookingCmd = new SqlCommand(insertBooking, con);

            bookingCmd.Parameters.AddWithValue("@bdate", DateTime.Now);
            bookingCmd.Parameters.AddWithValue("@tdate", travelDate);
            bookingCmd.Parameters.AddWithValue("@no", trainNo);
            bookingCmd.Parameters.AddWithValue("@class", travelClass);
            bookingCmd.Parameters.AddWithValue("@count", count);
            bookingCmd.Parameters.AddWithValue("@amount", amount);

            int bookingId =Convert.ToInt32(bookingCmd.ExecuteScalar());

            string passengerDetails = "";

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("\nPassenger " + i);

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Gender: ");
                string gender = Console.ReadLine();

                passengerDetails +=
                    "\n Passenger " + i +
                    "\n Name   : " + name +
                    "\n Age    : " + age +
                    "\n Gender : " + gender +
                    "\n";

                string passengerQuery =@"INSERT INTO Passengers VALUES(@bid,@name,@age,@gender)";

                SqlCommand passengerCmd = new SqlCommand(passengerQuery, con);

                passengerCmd.Parameters.AddWithValue("@bid", bookingId);
                passengerCmd.Parameters.AddWithValue("@name", name);
                passengerCmd.Parameters.AddWithValue("@age", age);
                passengerCmd.Parameters.AddWithValue("@gender", gender);

                passengerCmd.ExecuteNonQuery();
            }

            string updateSeats =
            $"UPDATE Trains SET {seatColumn} = {seatColumn} - @count WHERE TrainNo=@no";

            SqlCommand updateCmd = new SqlCommand(updateSeats, con);

            updateCmd.Parameters.AddWithValue("@count", count);
            updateCmd.Parameters.AddWithValue("@no", trainNo);

            updateCmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine("\n");
            Console.WriteLine("==============================================================");
            Console.WriteLine("                TRAIN RESERVATION TICKET                     ");
            Console.WriteLine("==============================================================");

            Console.WriteLine(" Booking ID      : " + bookingId);
            Console.WriteLine(" Train No        : " + trainNo);
            Console.WriteLine(" Travel Class    : " + travelClass);
            Console.WriteLine(" Travel Date     : " + travelDate.ToString("dd-MM-yyyy"));
            Console.WriteLine(" Passenger Count : " + count);
            Console.WriteLine(" Total Amount    : Rs." + amount);

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("                 PASSENGER DETAILS                           ");
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine(passengerDetails);

            Console.WriteLine("==============================================================");
            Console.WriteLine("             HAPPY JOURNEY - THANK YOU                       ");
            Console.WriteLine("==============================================================");
        }

        public void ViewBookings()
        {
            SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Bookings";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n================ BOOKING DETAILS ================");

            while (reader.Read())
            {
                Console.WriteLine(
                    "Booking ID : " + reader["BookingId"] +
                    " | Train No : " + reader["TrainNo"] +
                    " | Class : " + reader["TravelClass"] +
                    " | Passengers : " + reader["PassengerCount"] +
                    " | Amount : Rs." + reader["Amount"]);
            }

            Console.WriteLine("=================================================");

            con.Close();
        }
    }
}
