using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectWebForm.aspx.Board
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.SetFocus("txtName");
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

            // 커멘드

            SqlCommand objcmd = new SqlCommand("WriteBoard", objcon);
            objcmd.CommandType = CommandType.StoredProcedure;


            objcmd.Parameters.AddWithValue("@Name",txtName.Text);
            objcmd.Parameters.AddWithValue("@Title",txtTitle.Text);
            objcmd.Parameters.AddWithValue("@Content",txtContent.Text);
            objcmd.Parameters.AddWithValue("@Password",txtPassword.Text);

            objcon.Open();

            objcmd.ExecuteNonQuery();

            objcon.Close();



            btnList_Click(null, null); //리스트 페이지로 이동
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}