using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["MenuId"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems WHERE MenuId=@id", con);
                da.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable dt = new DataTable();
                da.Fill(dt);

                txtName.Text = dt.Rows[0]["ItemName"].ToString();
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["MenuId"] == null)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MenuItems(ItemName, Price) VALUES(@name,@price)", con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                SqlCommand cmd = new SqlCommand(
                    "UPDATE MenuItems SET ItemName=@name, Price=@price WHERE MenuId=@id", con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
}