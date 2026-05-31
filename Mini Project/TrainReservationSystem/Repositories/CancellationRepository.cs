using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrainReservationSystem.Data;



namespace TrainReservationSystem.Repositories
{
    public class CancellationRepository
    {
        DBConnection db = new DBConnection();

        public void CancelTicket()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());

            Console.Write("No Of Tickets To Cancel: ");
            int tickets = Convert.ToInt32(Console.ReadLine());

            con.Open();

            string query =
            @"SELECT TrainNo,
                     PassengerCount,
                     TravelClass
              FROM Bookings
              WHERE BookingId=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", bookingId);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                Console.WriteLine("Booking Not Found");

                con.Close();
                return;
            }

            int trainNo = Convert.ToInt32(reader["TrainNo"]);

            int passengerCount = Convert.ToInt32(reader["PassengerCount"]);

            string travelClass = reader["TravelClass"].ToString();

            reader.Close();

            if (tickets > passengerCount)
            {
                Console.WriteLine("Invalid Ticket Count");

                con.Close();
                return;
            }

            decimal refundAmount = tickets * 900;

            string cancelQuery =
            @"INSERT INTO Cancellations
              VALUES(@bid,@tickets,@refund,@date)";

            SqlCommand cancelCmd = new SqlCommand(cancelQuery, con);

            cancelCmd.Parameters.AddWithValue("@bid", bookingId);
            cancelCmd.Parameters.AddWithValue("@tickets", tickets);
            cancelCmd.Parameters.AddWithValue("@refund", refundAmount);
            cancelCmd.Parameters.AddWithValue("@date", DateTime.Now);

            cancelCmd.ExecuteNonQuery();

            string updateQuery = "";

            if (travelClass == "2AC")
            {
                updateQuery =
                "UPDATE Trains SET Seats2AC = Seats2AC + @tickets WHERE TrainNo=@no";
            }
            else if (travelClass == "3AC")
            {
                updateQuery =
                "UPDATE Trains SET Seats3AC = Seats3AC + @tickets WHERE TrainNo=@no";
            }
            else if (travelClass == "Sleeper")
            {
                updateQuery =
                "UPDATE Trains SET SleeperSeats = SleeperSeats + @tickets WHERE TrainNo=@no";
            }

            SqlCommand updateCmd = new SqlCommand(updateQuery, con);

            updateCmd.Parameters.AddWithValue("@tickets", tickets);
            updateCmd.Parameters.AddWithValue("@no", trainNo);

            updateCmd.ExecuteNonQuery();

            con.Close();

            Console.WriteLine("\n=================================");
            Console.WriteLine(" Cancellation Successful ");
            Console.WriteLine("=================================");

            Console.WriteLine("Refund Amount : Rs." + refundAmount);
        }

        public void ViewCancellationDetails()
        {
            SqlConnection con = db.GetConnection();

            string query = "SELECT * FROM Cancellations";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n===== CANCELLATION DETAILS =====");

            while (reader.Read())
            {
                Console.WriteLine(
                    "Cancellation ID: " + reader["CId"] +
                    " | Booking ID: " + reader["BookingId"] +
                    " | Tickets: " + reader["NoTickets"] +
                    " | Refund: " + reader["RefundAmount"]);
            }

            con.Close();
        }
    }
}
