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
    public partial class View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["Num"]))
            {
                Response.Write("잘못된 요청입니다.");
                Response.End(); // 현재 페이지에서 멈추기
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    // 넘겨져 온 번호에 해당하는 글 출력
                    DisplayData();
                }
            }
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("ViewBoard", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            // 파라미터 : List.aspx에서 넘겨온 쿼리스트링 값
            cmd.Parameters.AddWithValue("@Num", Request["Num"]);
            // 상세 보기 : DataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // 바인딩 : 각각의 컨트롤
            while (dr.Read())
            {
                lblNum.Text = dr["Num"].ToString();
                lblName.Text = dr["Name"].ToString();
                lblTitle.Text = dr["Title"].ToString();
                lblPostDate.Text = dr["PostDate"].ToString();
                lblContent.Text = dr["Content"].ToString();
                lblReadCount.Text = dr["ReadCount"].ToString();
            }

            dr.Close();
            con.Close();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            string strUrl = String.Empty;
            strUrl = "./Modify.aspx?Num=" + Request["Num"];
            Response.Redirect(strUrl);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 삭제 페이지로 현재 글의 번호 값 넘김
            Response.Redirect(String.Format("./Delete.aspx?Num={0}", Request["Num"]));
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("./List.aspx");
        }
    }
}