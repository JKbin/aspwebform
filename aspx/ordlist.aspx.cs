using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ProjectWebForm.aspx
{
    public partial class list : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable Table1 = new DataTable("MAT_ORD_DETAIL");
                Session["MAT_ORD_DETAIL"] = Table1;
                btnDisable();
                DisplayLabel();
                Label1.Visible = false;
            }
        }

        private void displaydata2()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                conn.Open();
                string query = @" SELECT ID,DETAIL_LINE,BUY_ORD_NO,QTY FROM WEB_PRT WHERE ID = @ID ";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter paramCity = new SqlParameter("@ID", SqlDbType.VarChar, 20);
                paramCity.Value = txtCode.Text;
                cmd.Parameters.Add(paramCity);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, "WEB_PRT");
                gridview2.DataSource = ds;
                gridview2.DataBind();
            }
        }

        private void btnDisable()
        {
            btnsubmit.Visible = false;
            txtCode.Visible = false;
            plBarCode.Visible = false;
        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            
                string query = @" SELECT COMP.COMP_NM , PLANT.PLANT_NM ,
                                  ORD_DET.PART_NO, ORD_DET.PART_NM, ORD_DET.UNIT, 
                                  ISNULL(ORD_DET.BUY_QTY - WEB.QTY,ORD_DET.BUY_QTY)- 
                                  ISNULL((SELECT SUM(QTY) FROM MAT_IN_DETAIL
                                  GROUP BY MAT_ORD_NO , ORD_DETAIL_LINE
                                  HAVING MAT_ORD_NO  = ORD_DET.BUY_ORD_NO AND ORD_DETAIL_LINE = ORD_DET.DETAIL_LINE),0)[BUY_QTY],
                                  ORD_DET.DETAIL_LINE,
                                  ORD.BUY_ORD_NO, BIZ.CUSTOMER_NAME
                                  FROM    MAT_ORD_DETAIL  AS  ORD_DET
                                  INNER JOIN  MAT_ORD      AS  ORD
                                  ON ORD_DET.BUY_ORD_NO = ORD.BUY_ORD_NO
                                  INNER JOIN  CIS_COMP    AS  COMP
                                  ON ORD.COMP_CD = COMP.COMP_CD
                                  INNER JOIN  CIS_PLANT    AS  PLANT
                                  ON ORD.PLANT_CD = PLANT.PLANT_CD
                                  INNER JOIN  CIS_BIZ_COMP  AS  BIZ
                                  ON ORD.CUSTOMER_CODE = BIZ.CUSTOMER_CODE
                                  LEFT OUTER  JOIN WEB_PRT      AS  WEB
                                  ON ORD_DET.BUY_ORD_NO = WEB.BUY_ORD_NO AND ORD_DET.DETAIL_LINE = WEB.DETAIL_LINE
                                  WHERE ORD.CUSTOMER_CODE = @CUSTOMER_CODE AND ISNULL(ORD_DET.BUY_QTY - WEB.QTY,ORD_DET.BUY_QTY)- 
                                  ISNULL((SELECT SUM(QTY) FROM MAT_IN_DETAIL
                                  GROUP BY MAT_ORD_NO , ORD_DETAIL_LINE
                                  HAVING MAT_ORD_NO  = ORD_DET.BUY_ORD_NO AND ORD_DETAIL_LINE = ORD_DET.DETAIL_LINE),0)>0
                                  ORDER BY BUY_ORD_NO ";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter paramCity = new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar, 20);
            paramCity.Value = Session["code"].ToString();
            cmd.Parameters.Add(paramCity);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MAT_ORD_DETAIL");
            gridview.DataSource = ds;
            gridview.DataBind();

           



        }

        

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string temp = Creating_TR_NO();
            txtCode.Text = temp;
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

                    cmd.Parameters.AddWithValue("@ID", temp);
                    cmd.Parameters.AddWithValue("@QTY", gridview.Rows[chk_index[i]].Cells[7].Text);
                    cmd.Parameters.AddWithValue("@DETAIL_LINE", gridview.Rows[chk_index[i]].Cells[8].Text);
                    cmd.Parameters.AddWithValue("@BUY_ORD_NO", gridview.Rows[chk_index[i]].Cells[9].Text);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
            }
            Generatebarcode();
            DisplayData();
            displaydata2();
            Label1.Visible = true;
        }

        private void DisplayLabel()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                conn.Open();
                string query = @" SELECT CUSTOMER_NAME FROM CIS_BIZ_COMP WHERE CUSTOMER_CODE = @CUSTOMER_CODE ";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter paramCity = new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar, 20);
                paramCity.Value = Session["code"].ToString();
                cmd.Parameters.Add(paramCity);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                lblCustomerNM.Text = reader["CUSTOMER_NAME"].ToString();
            }
        }

        private void Generatebarcode()
        {
            string barcode = txtCode.Text;
            System.Web.UI.WebControls.Image imgBarcode = new System.Web.UI.WebControls.Image();
            using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAHC39M Code 39 Barcode", 16);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whitebrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whitebrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarcode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                plBarCode.Controls.Add(imgBarcode);
            }
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

       

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayData();
            BtnDisplay();
        }

        private void BtnDisplay()
        {
            btnsubmit.Visible = true;
            txtCode.Visible = true;
            plBarCode.Visible = true;
        }

        /// <summary>
        ///  페이징 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            DisplayData();
        }

        protected void gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview2.PageIndex = e.NewPageIndex;
            displaydata2();
        }
    }
}