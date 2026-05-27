using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace FoodOrderManagement
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems WHERE MenuId=@id", con);
            da.SelectCommand.Parameters.AddWithValue("@id", id);

            DataTable dt = new DataTable();
            da.Fill(dt);

            lblName.Text = dt.Rows[0]["ItemName"].ToString();
            lblPrice.Text = dt.Rows[0]["Price"].ToString();
        }
    }
}
