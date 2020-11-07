using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Data;
using System.Drawing;

namespace ProjectWebForm
{

    public partial class test2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //        base.VerifyRenderingInServerForm(control);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Get path from web.config file to upload
            string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            string filename = string.Empty;
            // To check wheather file is selected or not to upload
            if (FileUploadToServer.HasFile)
            {
                try
                {
                    string[] allowedFiles = { ".xls", ".xlsx" };
                    string FileExt = Path.GetExtension(FileUploadToServer.PostedFile.FileName);
                    bool isValidFile = allowedFiles.Contains(FileExt);
                    if (!isValidFile)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Please upload only excel";
                    }
                    else
                    {
                        int FileSize = FileUploadToServer.PostedFile.ContentLength;
                        if (FileSize <= 1048576)
                        {
                            filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));
                            FileUploadToServer.SaveAs(Server.MapPath(FilePath) + filename);
                            string filePath = Server.MapPath(FilePath) + filename;

                            OleDbConnection con = null;
                            if (FileExt == ".xlsx")
                            {
                                //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extened Properties='Excel 12.0; HDR=YES; IMEX=1';Persist Security Info=False;")
                                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                            }
                            else if (FileExt == ".xls")
                            {
                                lblMsg.Text = "엑셀파일의 확장자명은 .xls 입니다.";
                            }
                            con.Open();
                            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
                            string Excelquery = @"SELECT * FROM [" + getExcelSheetName + @"A:R]";
                            OleDbCommand Excelcommand = new OleDbCommand(Excelquery, con);

                            OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(Excelcommand);
                            DataSet ExcelDataset = new DataSet();
                            ExcelAdapter.Fill(ExcelDataset);
                            con.Close();
                            GridView1.DataSource = ExcelDataset;
                            GridView1.DataBind();


                        }
                        else
                        {
                            lblMsg.Text = "Attatchment file size should not be greater then 1 MB!";
                        }
                    }

                }
                catch (Exception)
                {
                    lblMsg.Text = "Error occurred while uploading a file!";
                }
            }

        }

        protected void btndownload_Click(object sender, EventArgs e)
        {


        }








       



    }
}