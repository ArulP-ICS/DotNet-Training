using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace TrainReservationSystem.Data
{
    public class DBConnection
    {
        public string connectionString = "Data Source=ICS-LT-CFW37V3\\SQLEXPRESS;Initial Catalog=TrainReservationDB;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
