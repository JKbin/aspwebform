using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace ProjectWebForm
{
    public partial class gridtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            datagridview();
        }

        private void datagridview()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString()))
            {
                conn.Open();
                DataSet ds = new DataSet();
                string query = @"SELECT 
                                    REQ.BUY_REQ_NO[요청번호],	COMP.COMP_NM[회사명],
                                    COMP.COMP_TEL[전화],		COMP.COMP_FAX[팩스],
                                    PLANT.PLANT_NM[현장명],		REQ.BUY_REQ_NO[요청번호],
                                    USEER.USER_NM[요청자],		 (CONVERT(VARCHAR(10), REQ.REQ_DATE, 120))[요청일자]
                                    FROM MAT_REQ AS REQ
                                    INNER JOIN CIS_COMP AS COMP
                                    ON REQ.COMP_CD = COMP.COMP_CD
                                    INNER JOIN CIS_PLANT AS PLANT
                                    ON REQ.PLANT_CD = PLANT.PLANT_CD
                                    INNER JOIN CIS_USER AS USEER
                                    ON REQ.CREATION_BY = USEER.USER_ID 
                                    WHERE BUY_REQ_NO = @BUY_REQ_NO ";

                SqlCommand cmd = new SqlCommand(query, conn);

                //SqlParameter paramCity = new SqlParameter("@BUY_REQ_NO", SqlDbType.VarChar, 30);
                //paramCity.Value = txtserch.Text;
                //cmd.Parameters.Add(paramCity);

                cmd.Parameters.AddWithValue("@BUY_REQ_NO", "%" + txtserch.Text + "%");


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, " MAT_REQ ");
                GridView1.DataSource = ds;
                //GridView1.DataMember = " MAT_REQ ";
                GridView1.DataBind();

            }
        }
    }
}