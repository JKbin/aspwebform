using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectWebForm.aspx
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Code"] != null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString()))
            {
                con.Open();
                string query = @" SELECT COUNT(*) FROM CIS_BIZ_COMP WHERE CUSTOMER_CODE=@CUSTOMER_CODE AND CUSTOMER_PWD=@CUSTOMER_PWD ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", txtCustomerCode.Text);
                cmd.Parameters.AddWithValue("CUSTOMER_PWD", txtCustomerPwd.Text);
                string output = cmd.ExecuteScalar().ToString();

                // Login Success
                if (output == "1")
                {
                    // create a session
                    Session["Code"] = txtCustomerCode.Text;
                    Response.Redirect("main.aspx");
                }
                // Login Fail
                else
                {
                    lblMessage.Text = "Please Check your Code or Password!";
                    txtCustomerCode.Text = "";
                    txtCustomerPwd.Text = "";
                }
            }
        }
    }
}