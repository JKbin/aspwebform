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
    public partial class View : System.Web.UI.Page
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
            SqlConnection con = new SqlConnection(

       ConfigurationManager.ConnectionStrings

       ["connect"].ConnectionString);

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

                this.lblNum.Text = dr["Num"].ToString();

                this.lblName.Text = dr["Name"].ToString();

                this.lblTitle.Text = dr["Title"].ToString();

                this.lblPostDate.Text = dr["PostDate"].ToString();

                // 인코딩에 따른 Content 출력 3가지 방법

                // Write.aspx페이지에서 <%page 부분에 ValidateRequest="false" 추가

                //string encoding = dr["Encoding"].ToString(); // Text/HTml/Mixed

                //if (encoding == "Text") // 입력한 모양 그대로 출력

                //{

                //    this.lblContent.Text = dr["Content"].ToString()

                //        .Replace("&", "&amp;").Replace("<", "&lt;")

                //        .Replace(">", "&gt;")

                //        .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;")

                //        .Replace("\r\n", "<br />");

                //}



                //else if (encoding == "Mixed") // 태그는 실행하되, 엔터는 처리

                //{

                this.lblContent.Text = dr["Content"].ToString();

                //        .Replace("\r\n", "<br />");

                //}



                //else // HTML로 변환해서 출력

                //{

                //    this.lblContent.Text = dr["Content"].ToString();

                //}



                //this.lblContent.Text = dr["Content"].ToString();



                this.lblReadCount.Text = dr["ReadCount"].ToString();


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