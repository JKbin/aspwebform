using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWebForm
{
    public partial class LoginSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                txtuser.Text = "welcome " + Session["user"].ToString(); 
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("Main.aspx");
        }
    }
}