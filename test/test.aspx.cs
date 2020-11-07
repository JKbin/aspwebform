//using System;
//using System.Data;
//using System.Data.OleDb;
//using System.IO;
//using System.Text;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

//namespace ProjectWebForm.test
//{
//    public partial class test : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }

//        protected void UploadButton_Click(object sender, EventArgs e)
//        {
//            if (FileUpload1.HasFile == false)
//            {
//                Response.Write("<script>alert('엑셀파일을 업로드해주세요.');</script>");
//            }
//            else
//            {
//                Fileup1();
//            }
//        }





//        private void InportExcelDb(string url)
//        {

//            //파일이 저장 될 웹서버 폴더

//            string fPath = "C:\\homepage/phoenixs/";
//            string fName = fPath + url;

//            string strConn = "";

//​

//           //ExcelFileType함수 : 엑셀 버전 확인함수다..
//           if (ExcelFileType(fName) == 0)
//            {
//                //확장명 XLS (Excel 97~2003 용)
//                strConn = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;Persist Security Info=False""", fName);
//            }
//            else if (ExcelFileType(fName) == 1)
//            {
//                // 확장명 XLSX (Excel 2007 이상)
//                strConn = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;Persist Security Info=False""", fName);
//            }
//            else
//            {

//                Response.Write("지정된 형식이 아닙니다!!");
//            }

//            OleDbConnection oleConn = new OleDbConnection(strConn);

//            //Sheet1 : 기본적으로 엑셀 실행 시 생성되는 기본시트..이 소스는 Sheet1에 있는것만 읽어온다..시트명이 상이할경우 상황에 따라서 변형하여 사용하시면 될듯..

//            OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", oleConn);
//            oleConn.Open();

//            OleDbDataReader dr = command.ExecuteReader();

//            while (dr.Read())
//            {
//                try
//                {   //시트 1에 2번째 열까지만 가져와 화면에 뿌려준다..그 이상 있을경우에는 dr[2],dr[3],dr[4]...등등 확장해서 사용     

//                    //Response.Write(dr[0].ToString(), dr[1].ToString());
//                    Response.Write(dr[0].ToString());
//                }
//                catch (Exception ex)
//                {
//                    Response.Write(dr[0].ToString());
//                }
//            }
//            Response.Write("<script>alert('읽기를 완료했습니다.');</script>");
//            oleConn.Close();
//        }







//        public static int ExcelFileType(string XlsFile)
//        {
//            byte[,] ExcelHeader = {
//            { 0xD0, 0xCF, 0x11, 0xE0, 0xA1 }, // XLS  File Header
//            { 0x50, 0x4B, 0x03, 0x04, 0x14 }  // XLSX File Header
//        };

//            // result -2=error, -1=not excel , 0=xls , 1=xlsx
//            int result = -1;

//            FileInfo FI = new FileInfo(XlsFile);
//            FileStream FS = FI.Open(FileMode.Open);

//            try
//            {
//                byte[] FH = new byte[5];

//                FS.Read(FH, 0, 5);

//                for (int i = 0; i < 2; i++)
//                {
//                    for (int j = 0; j < 5; j++)
//                    {
//                        if (FH[j] != ExcelHeader[i, j]) break;
//                        else if (j == 4) result = i;
//                    }
//                    if (result >= 0) break;
//                }
//            }
//            catch
//            {
//                result = (-2);
//                //throw e;
//            }
//            finally
//            {
//                FS.Close();
//            }
//            return result;
//        }




//        protected void Fileup1()
//        {
//            //파일 유무확인
//            if (FileUpload1.HasFile == true)
//            {
//                //업로드 절대 경로 설정

//                //현재 년월일을 불러와 폴더 생성 후 그곳에 저장..
//                string upDir = "C:\\Users\\admin\\Desktop\\save" + DateTime.Now.ToString("yyyyMMdd") + "\\";
//​

//            //업로드된 절대 URL
//            string dirURL = "";

//​

//            //업로드 시작
//            DirectoryInfo di = new DirectoryInfo(upDir);


//                if (di.Exists == false)
//                {
//                    di.Create();
//                }

//                //File 확장자 유효성 체크
//                bool fileTypeOK = false;




//                //File명 가져오기
//                string fName = FileUpload1.FileName;

//​

//            //업로드 File 경로 설정
//            string fFullName = upDir + fName;

//​

//            //File 전체 경로 가져오기
//            FileInfo fInfo = new FileInfo(fFullName);

//​

//            //File 확장자 체크
//            String fileExtension = Path.GetExtension(fName).ToLower();
//                String[] allowedExtensions = { ".xls", ".xlsx" };

//                for (int i = 0; i < allowedExtensions.Length; i++)
//                {
//                    if (fileExtension == allowedExtensions[i])
//                        fileTypeOK = true;
//                }


//                if (!fileTypeOK)
//                {
//                    Response.Write("<script>alert('엑셀파일만 발송가능합니다!');</script>");
//                }
//                else
//                {

//                    if (fInfo.Exists == true)
//                    {
//                        int findex = 0;
//                        string fExt = fInfo.Extension;
//                        string fRealName = fName.Replace(fExt, "");
//                        string newFileName = "";
//                        do
//                        {
//                            findex++;
//                            newFileName = fRealName + "_" + findex.ToString() + fExt;
//                            fInfo = new FileInfo(upDir + newFileName);
//                        } while (fInfo.Exists);

//                        fFullName = upDir + newFileName;
//                        fName = newFileName;
//                    }

//                    FileUpload1.PostedFile.SaveAs(fFullName);
//                    fInfo = new FileInfo(fFullName);
//                    dirURL = "/Files/" + DateTime.Now.ToString("yyyyMMdd") + "/" + fName;

//​

//                //엑셀 파일 읽어서 화면에 뿌리는 함수 호출!
//                InportExcelDb(dirURL);
//                }

//            }
//            else
//            {

//            }
//        }
//    }

//}