using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Problem2 : Page
    {
        

        Dictionary<string, Product> products =
            new Dictionary<string, Product>()
        {
            {
                "Laptop",
                new Product
                {
                    Image = "~/Images/laptop.jpg",
                    Price = "₹75,000"
                }
            },

            {
                "Mobile",
                new Product
                {
                    Image = "~/Images/mobile.jpg",
                    Price = "₹80,000"
                }
            },

            {
                "Headphones",
                new Product
                {
                    Image = "~/Images/headphones.jpg",
                    Price = "₹5,000"
                }
            }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                ddlProducts.Items.Add("Select Product");

               
                foreach (var item in products.Keys)
                {
                    ddlProducts.Items.Add(item);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;

            if (products.ContainsKey(selected))
            {
                imgProduct.ImageUrl = products[selected].Image;
                lblPrice.Text = "";
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;

            if (products.ContainsKey(selected))
            {
                lblPrice.Text =
                    "Price: " + products[selected].Price;
            }
            else
            {
                lblPrice.Text =
                    "Please select a product.";
            }
        }
    }

    public class Product
    {
        public string Image { get; set; }

        public string Price { get; set; }
    }
}