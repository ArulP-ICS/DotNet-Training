using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrainReservationSystem.Data;


namespace TrainReservationSystem.Repositories
{
    public class UserRepository
    {
        DBConnection db = new DBConnection();

        public string Login(string username, string password)
        {
            SqlConnection con = db.GetConnection();

            string query = "SELECT UserType FROM Users WHERE Username=@u AND Password=@p";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            con.Open();

            object result = cmd.ExecuteScalar();

            con.Close();

            if (result != null)
                return result.ToString();

            return null;
        }
    }
}
