using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWebForm.test
{
    public partial class Listtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
                BindData();
            }
        }

        private void BindData()
        {

        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            string query = @"SELECT 
                            REQ.BUY_REQ_NO,	COMP.COMP_NM,
                            COMP.COMP_TEL, COMP.COMP_FAX,
                            PLANT.PLANT_NM, USEER.USER_NM		 
                            FROM MAT_REQ AS REQ
                            INNER JOIN CIS_COMP AS COMP
                            ON REQ.COMP_CD = COMP.COMP_CD
                            INNER JOIN CIS_PLANT AS PLANT
                            ON REQ.PLANT_CD = PLANT.PLANT_CD
                            INNER JOIN CIS_USER AS USEER
                            ON REQ.CREATION_BY = USEER.USER_ID ";

            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MAT_REQ");
            ctlBasicList.DataSource = ds;
            ctlBasicList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}