﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.CompilerServices;
using ProjectWebForm.aspx.Board;
using System.Security.Authentication.ExtendedProtection;
using System.Web.Services.Description;

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
                                ON BIZ.CUSTOMER_CODE = ORD.CUSTOMER_CODE 
                                WHERE ORD.CUSTOMER_CODE LIKE @ORD.CUSTOMER_CODE ";



            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.Parameters.AddWithValue("ORD.CUSTOMER_CODE",Session["code"].ToString());
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
            string temp = Creating_TR_NO();
            List<int> chk_count = new List<int>();
            List<int> chk_index = new List<int>();
            // 체크박스가 체크되어있는지 확인
            for (int i = 0; i < gridview.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gridview.Rows[i].Cells[0].FindControl("ordcheck");
                if (chk.Checked == true)
                {
                    chk_count.Add(i);
                }
            }
            // 체크박스에 선택된 rowindex 저장
            foreach (GridViewRow rw in gridview.Rows)
            {
                CheckBox chk = (CheckBox)rw.Cells[0].FindControl("ordcheck");
                if (chk.Checked == true)
                {
                    chk_index.Add(rw.RowIndex);
                }
            }

            for (int i = 0; i < chk_count.Count; i++)
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
                {
                    DataSet ds = new DataSet();
                    conn.Open();

                    string query = @" INSERT INTO WEB_PRT (ID, DETAIL_LINE, BUY_ORD_NO, QTY) 
                                          VALUES (@ID, @DETAIL_LINE, @BUY_ORD_NO, @QTY) ";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("ID", temp);
                    cmd.Parameters.AddWithValue("QTY", gridview.Rows[chk_index[i]].Cells[7].Text);
                    cmd.Parameters.AddWithValue("DETAIL_LINE", gridview.Rows[chk_index[i]].Cells[8].Text);
                    cmd.Parameters.AddWithValue("BUY_ORD_NO", gridview.Rows[chk_index[i]].Cells[9].Text);

                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
                DisplayData();
            }
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

        /// <summary>
        /// Gridview Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridview.Rows[e.RowIndex];
            int DETAIL_LINE = Convert.ToInt32(gridview.DataKeys[e.RowIndex].Values[0]);
            decimal qty = decimal.Parse((row.Cells[7].Controls[0] as TextBox).Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                con.Open();
                string query = @"UPDATE MAT_ORD_DETAIL SET BUY_QTY = @BUY_QTY WHERE DETAIL_LINE = @DETAIL_LINE";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DETAIL_LINE", DETAIL_LINE);
                cmd.Parameters.AddWithValue("@BUY_QTY", qty);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            gridview.EditIndex = -1;
            DisplayData();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = gridview.Rows[3].Cells[9].Text;
        }
    }
}