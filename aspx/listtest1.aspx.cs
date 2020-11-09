using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ProjectWebForm.aspx
{
    public partial class listtest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
            string query = @"SELECT COMP.COMP_NM , PLANT.PLANT_NM ,
                                    ORD_DET.PART_NO, ORD_DET.PART_NM, ORD_DET.UNIT, ORD_DET.BUY_QTY , ORD.BUY_ORD_NO, BIZ.CUSTOMER_NAME
                                    FROM MAT_ORD_DETAIL AS ORD_DET
                                    LEFT OUTER JOIN MAT_ORD AS ORD
                                    ON ORD_DET.BUY_ORD_NO = ORD.BUY_ORD_NO
                                    LEFT OUTER JOIN CIS_COMP AS COMP
                                    ON ORD.COMP_CD = COMP.COMP_CD
                                    LEFT OUTER JOIN CIS_PLANT AS PLANT
                                    ON ORD.PLANT_CD = PLANT.PLANT_CD
                                    LEFT OUTER JOIN CIS_BIZ_COMP AS BIZ
                                    ON ORD.CUSTOMER_CODE = BIZ.CUSTOMER_CODE ";



            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "MAT_ORD_DETAIL");
            gridview.DataSource = ds;
            gridview.DataBind();
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview.PageIndex = e.NewPageIndex;
            gridview.DataBind();
            DisplayData();
        }
    }
}