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
            if (Session["user"] != null)
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
                string query = @" SELECT COUNT(*) FROM CIS_USER WHERE USER_ID=@USER_ID AND USER_PWD=@USER_PWD ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@USER_ID", txtUserId.Text);
                cmd.Parameters.AddWithValue("USER_PWD", txtUserPwd.Text);
                string output = cmd.ExecuteScalar().ToString();

                // Login Success
                if (output == "1")
                {
                    // create a session
                    Session["user"] = txtUserId.Text;
                    Response.Redirect("main.aspx");
                }
                // Login Fail
                else
                {
                    lblMessage.Text = "Please Check your ID or Password!";
                    txtUserId.Text = "";
                    txtUserPwd.Text = "";
                }
            }
        }
    }
}