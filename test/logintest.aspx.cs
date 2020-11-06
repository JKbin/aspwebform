using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

namespace ProjectWebForm
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            loginporcess();
        }

        private void loginporcess()
        {
            SqlConnection con = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=HIAIRMES;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM CIS_USER WHERE USER_ID=@USERNAME AND USER_PWD=@WORD", con);
            cmd.Parameters.AddWithValue("@username", txtid.Text);
            cmd.Parameters.AddWithValue("word", txtpwd.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                Response.Redirect("LoginSuccess.aspx");
            }
            else
            {
                Label3.Text = "Your username and word is incorrect";
                Label3.ForeColor = System.Drawing.Color.Red;

            }


        }
    }
}