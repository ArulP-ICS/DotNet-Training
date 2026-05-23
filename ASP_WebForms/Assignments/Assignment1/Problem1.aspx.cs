using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Assignment1
{
    public partial class Problem1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
           
            if (!Page.IsValid)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please fix validation errors.";
                return;
            }

            
            if (txtName.Text.Trim().ToLower() ==
                txtFamily.Text.Trim().ToLower())
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Name and Family Name must be different.";
                return;
            }

          
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "All validations passed successfully!";
        }
    }
}