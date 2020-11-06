using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// add using
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace ProjectWebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        
        /// <summary>
        /// cshtml에 form 구문안에 textbox를 삽입 할 때 뜨는 에러를 고쳐주는데 왜 추가하는지 모르겠음
        /// </summary>
        /// <param name="control"></param>
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            // Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                    Response.Redirect("Main.aspx");
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