using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectWebForm.Models
{
    public partial class Mlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Mlogin.aspx");
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
                //string query = @" SELECT COUNT(*) FROM CIS_USER WHERE USER_ID=@USER_ID AND USER_PWD=@USER_PWD ";
                string query = @" SELECT COUNT(*) FROM CIS_BIZ_COMP WHERE CUSTOMER_CODE=@CUSTOMER_CODE AND CUSTOMER_PWD=@CUSTOMER_PWD ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CUSTOMER_CODE", txtCode.Text);
                cmd.Parameters.AddWithValue("CUSTOMER_PWD", txtpwd.Text);
                string output = cmd.ExecuteScalar().ToString();

                // Login Success
                if (output == "1")
                {
                    // create a session
                    Session["user"] = txtCode.Text;
                    Response.Redirect("../aspx/main.aspx");
                }
                // Login Fail
                else
                {
                    Label1.Text = "Please Check your ID or Password!";
                    txtCode.Text = "";
                    txtpwd.Text = "";
                }
            }
        }
    }
}