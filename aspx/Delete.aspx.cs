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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["Num"]))
            {

                Response.Write("잘못된 요청입니다.");
                Response.End();
            }
            else
            {
                // 레이블에 넘겨져 온 번호 값 출력
                this.lblNum.Text = Request["Num"];
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // 취소 버튼 클릭시 뒤로(상세 보기 페이지) 이동

            Response.Redirect("View.aspx?Num=" + Request["Num"]);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsPasswordCorrect())

            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

                conn.Open();

                SqlCommand cmd = new SqlCommand("DeleteBoard", conn);

                cmd.CommandType = CommandType.StoredProcedure;



                // 파라미터 : List.aspx에서 넘겨온 쿼리스트링값

                cmd.Parameters.AddWithValue("@Num", Request["Num"]);



                cmd.ExecuteNonQuery(); // 삭제



                // 삭제 후 리스트로 이동

                Response.Redirect("List.aspx");
            }
            else
            {
                this.lblError.Text = "암호가 틀립니다.";
            }
        }

        private bool IsPasswordCorrect()
        {
            bool result = false;

            SqlConnection conn = new SqlConnection

                (ConfigurationManager.ConnectionStrings

                ["connect"].ConnectionString);



            conn.Open();



            SqlCommand cmd = new SqlCommand(

                "Select * From BRD_COMMON Where Num = @Num And Password = @Password"

                , conn);



            // 파라미터 추가

            cmd.Parameters.AddWithValue("@Num", Request["Num"]);

            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);



            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read()) // 데이터가 읽혀진다면, 번호와 암호가 맞음

            {

                result = true;

            }

            return result;

        }
    }
}