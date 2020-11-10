using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWebForm.aspx
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("login.aspx");
        }

        protected void lbtnboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }

        protected void lbtncompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("company.aspx");
        }

        protected void lbtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("ordlist.aspx");
        }

        protected void lbtnmain_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }
    }
}