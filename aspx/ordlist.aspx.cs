using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ProjectWebForm.aspx
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
                DataTable Table1 = new DataTable("MAT_ORD_DETAIL");
                Session["MAT_ORD_DETAIL"] = Table1;
            }
        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            string query = @"SELECT 
                                COMP.COMP_NM,
                                PLANT.PLANT_NM,
                                DET.BUY_ORD_NO,
                                BIZ.CUSTOMER_NAME,
                                DET.PART_NO,
                                DET.PART_NM,
                                DET.UNIT,
                                DET.BUY_QTY,
                                DET.DETAIL_LINE,
                                ORD.RMK
                                FROM MAT_ORD_DETAIL AS DET
                                INNER JOIN MAT_ORD AS ORD
                                ON DET.BUY_ORD_NO = ORD.BUY_ORD_NO
                                INNER JOIN CIS_COMP AS COMP
                                ON ORD.COMP_CD = COMP.COMP_CD
                                INNER JOIN CIS_PLANT AS PLANT
                                ON ORD.PLANT_CD = PLANT.PLANT_CD
                                INNER JOIN CIS_BIZ_COMP AS BIZ
                                ON BIZ.CUSTOMER_CODE = ORD.CUSTOMER_CODE ";



            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MAT_ORD_DETAIL");
            gridview.DataSource = ds;
            gridview.DataBind();
        }

        /// <summary>
        /// 페이징 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            gridview.DataBind();
            DisplayData();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            // 체크박스 체크된 갯수체크 > 체크된개수만큼 주문번호를 기준으로 Header 정보 생성

            List<int> alist = new List<int>();
            //삭제 체크박스가 체크된 행의 인덱스 번호를 리스트에 저장
            //for (int i = 0; i < gridview.Rows.Count; i++)
            //{
            //    if (gridview.Rows[i].Cells[0].Controls[0].ToString
            //        Value.ToString() == "True")
            //        alist.Add(i);
            //}



        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {

            


        }





        private string Creating_TR_NO()
        {
            string retrun_value = "";

            string[] a = DateTime.Now.ToString().Split(' ');
            a[0] = a[0].Replace("-", string.Empty).Trim();
            string temp = "TN" + a[0];

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"  SELECT ID FROM WEB_PRT
                                      WHERE ID LIKE @ID
                                      ORDER BY ID DESC
                                      OFFSET 0 ROWS
                                      FETCH NEXT 1 ROWS ONLY ";

                cmd.Parameters.AddWithValue("@ID", temp + "%");


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    retrun_value = reader[0].ToString();
                }
            }
            if (retrun_value == string.Empty)
            {
                return temp + "0000";
            }
            else
            {
                return "TN" + (decimal.Parse(retrun_value.Substring(2)) + 1).ToString();
            }

        }



        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview.EditIndex = e.NewEditIndex;
            DisplayData();
        }

        protected void gridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview.EditIndex = -1;
            DisplayData();
        }

        protected void gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gridview.Rows[e.RowIndex];
            int DETAIL_LINE = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Values[0]);
            decimal qty = decimal.Parse((row.Cells[7].Controls[0] as TextBox).Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                con.Open();
                string query = @"UPDATE MAT_ORD_DETAIL SET BUY_QTY = @BUY_QTY WHERE DETAIL_LINE = @DETAIL_LINE";
                SqlCommand cmd = new SqlCommand(query,con);

                cmd.Parameters.AddWithValue("@DETAIL_LINE", DETAIL_LINE);
                cmd.Parameters.AddWithValue("@BUY_QTY", qty);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gridview.EditIndex = -1;
            DisplayData();
        }

        protected void ordcheck_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}