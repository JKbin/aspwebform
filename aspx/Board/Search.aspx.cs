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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {

                DisplayData(); // 그리드뷰 컨트롤에 데이터 출력

            }
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(

       ConfigurationManager.ConnectionStrings

       ["connect"].ConnectionString);



            SqlCommand cmd = new SqlCommand("SearchBoard", con);

            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@SearchField"

                , Request["SearchField"]); //Name, title

            cmd.Parameters.AddWithValue("@SearchQuery"

                , Request["SearchQuery"]); //홍길동, 안녕



            SqlDataAdapter da = new SqlDataAdapter(cmd);



            DataSet ds = new DataSet();



            da.Fill(ds, "BRD_COMMON");



            this.ctlSearchList.DataSource = ds.Tables[0];

            this.ctlSearchList.DataBind();
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");

        }
    }
}