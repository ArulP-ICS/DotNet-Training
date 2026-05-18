using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace BankingApplication
{
    public partial class BankForm : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

       
        string GenerateAccountNumber()
        {
            Random rnd = new Random();
            return "BANK" + rnd.Next(10000000, 99999999);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";

           
            if (!Page.IsValid)
                return;

            if (txtEmail.Text.Trim() != txtReEmail.Text.Trim())
            {
                lblMsg.Text = "Email mismatch";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (txtPassword.Text != txtRePassword.Text)
            {
                lblMsg.Text = "Password mismatch";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

    
            if (rblGender.SelectedIndex == -1)
            {
                lblMsg.Text = "Please select Gender";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string accNo = GenerateAccountNumber();
            string imgPath = "";

          
            if (fuImage != null && fuImage.HasFile)
            {
                try
                {
                    string folder = Server.MapPath("~/Images/");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string fileName = DateTime.Now.Ticks + "_" + Path.GetFileName(fuImage.FileName);
                    imgPath = "Images/" + fileName;

                    fuImage.SaveAs(Server.MapPath("~/" + imgPath));
                }
                catch
                {
                    lblMsg.Text = "Image upload failed";
                    return;
                }
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM Customers WHERE Email=@e OR Mobile=@m", con);

                check.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                check.Parameters.AddWithValue("@m", txtMobile.Text.Trim());

                int count = (int)check.ExecuteScalar();

                if (count > 0)
                {
                    lblMsg.Text = "User already registered! Use Login.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }

          
                SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Customers
                (FullName, Gender, Address, Email, Mobile, PAN, Aadhaar, Password, AccountNumber, ImagePath)
                VALUES
                (@Name, @Gender, @Address, @Email, @Mobile, @PAN, @Aadhaar, @Password, @AccountNo, @Image)", con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@PAN", txtPAN.Text.Trim());
                cmd.Parameters.AddWithValue("@Aadhaar", txtAadhaar.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@AccountNo", accNo);
                cmd.Parameters.AddWithValue("@Image", imgPath);

                cmd.ExecuteNonQuery();

                lblMsg.Text = "Registered Successfully! Account No: " + accNo;
                lblMsg.ForeColor = System.Drawing.Color.Green;

                ClearForm();
            }
        }

       
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT FullName, Gender, Email, Mobile, AccountNumber, ImagePath 
                  FROM Customers
                  WHERE (Mobile=@User OR AccountNumber=@User)
                  AND Password=@Pass", con);

                da.SelectCommand.Parameters.AddWithValue("@User", txtLogin.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@Pass", txtLoginPass.Text.Trim());

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvUsers.Visible = true;
                    gvUsers.DataSource = dt;
                    gvUsers.DataBind();

                    lblMsg.Text = "✅ Login Successful!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    gvUsers.Visible = false;
                    lblMsg.Text = "❌ Invalid Login!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        void ClearForm()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtReEmail.Text = "";
            txtMobile.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtPAN.Text = "";
            txtAadhaar.Text = "";

            rblGender.ClearSelection();
        }
    }
}


