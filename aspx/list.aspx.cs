using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectWebForm.aspx.Board
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ListBoard", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "BRD_COMMON");
            ctlBasicList.DataSource = ds.Tables[0];
            ctlBasicList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // 검색페이지로 필드명과 검색어 전달
            string strUrl = string.Format("Search.aspx?SearchField={0}&SearchQuery={1}"
                ,lstSearchField.SelectedValue, txtSearchQuery.Text);

            Response.Redirect(strUrl);
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("Write.aspx");
        }
    }
}