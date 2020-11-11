using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebForm.aspx
{
    public partial class listtest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Display the subtotal without tax when the page is first loaded.
            if (!IsPostBack)
            {

                // Calculate the subtotal and display the result in currency format.
                Message.Text = CalculateTotal(false).ToString("c");

            }
        }

        double CalculateTotal(bool Taxable)
        {

            // Calculate the subtotal for the example.
            double Result = 1.99 + 2.99 + 3.99;

            // Add tax, if applicable.
            if (Taxable)
            {
                Result += Result * 0.086;
            }

            return Result;

        }

        protected void Check_Clicked(object sender, EventArgs e)
        {
            // Calculate the subtotal and display the result in currency format.
            // Include tax if the check box is selected.
            Message.Text = CalculateTotal(checkbox1.Checked).ToString("c");
        }
    }
}