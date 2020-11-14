<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectWebForm.aspx.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Master login Form Responsive Widget Template  :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content=" Master  Login Form Widget Tab Form,Login Forms,Sign up Forms,Registration Forms,News letter Forms,Elements" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="../css/login.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Cormorant+SC:300,400,500,600,700" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet" />
    <style>
        #btnlogin {
            margin-top: 30px;
        }
        #lblMessage {
            color: white;
        }
    </style>
</head>
<body>
    <div class="padding-all">
        <div class="header">
            <h1>MES FOR FUELCELL</h1>
        </div>
        <div class="design-w3l">
            <div class="mail-form-agile">
                <form id="form1" runat="server" action="#" method="post">
                    <asp:TextBox ID="txtCustomerCode" placeholder="UserId" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtCustomerPwd" type="Password" placeholder="Password" runat="server"></asp:TextBox>
                    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" />
                </form>
            </div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <div class="clear"></div>
        </div>
    </div>
</body>
</html>
