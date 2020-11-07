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
    public partial class Modify : System.Web.UI.Page
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
                //수정페이지는 처음 로드시에만 이전 데이터 읽어오자.
                if (!Page.IsPostBack)

                {
                    // 넘겨져 온 번호값에 해당하는 글 출력
                    DisplayData();
                }
            }
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager

        .ConnectionStrings["connect"].ConnectionString);



            con.Open();



            // 기존 데이터 읽어다 출력

            SqlCommand cmd = new SqlCommand("ViewBoard", con);

            cmd.CommandType = CommandType.StoredProcedure;



            // 파라미터 : List.aspx에서 넘겨온 쿼리스트링 값

            cmd.Parameters.AddWithValue("@Num", Request["Num"]);



            // 상세보기 : DataReader

            SqlDataReader dr = cmd.ExecuteReader();



            // 바인딩 : 각각의 컨트롤

            while (dr.Read())

            {

                lblNum.Text = dr["Num"].ToString();

                txtName.Text = dr["Name"].ToString();



                txtTitle.Text = dr["Title"].ToString();

                txtContent.Text = dr["Content"].ToString();




            }

            dr.Close();
            con.Close();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (IsPasswordCorrect())

            {
                // Write.aspx와 동일한 패턴
                SqlConnection objcon = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
                SqlCommand objcmd = new SqlCommand("ModifyBoard", objcon);
                objcmd.CommandType = CommandType.StoredProcedure;

                objcmd.Parameters.AddWithValue("@Name", txtName.Text);
                objcmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                objcmd.Parameters.AddWithValue("@Content", txtContent.Text);
                objcmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                objcmd.Parameters.AddWithValue("@Num", lblNum.Text);
                
                objcon.Open();
                objcmd.ExecuteNonQuery();
                objcon.Close();


                // 상세보기로 가서 수정 확인
                Response.Redirect("View.aspx?Num=" + Request["Num"]);
            }



            else
            {
                lblError.Text = "암호가 틀립니다.";
            }

        }

        private bool IsPasswordCorrect()
        {
            bool result = false;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * From BRD_COMMON Where Num = @Num And Password = @Password", conn);

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

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");

        }
    }
}