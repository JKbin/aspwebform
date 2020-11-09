<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mlogin.aspx.cs" Inherits="ProjectWebForm.Models.Mlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/Mlogin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="box" method="post">
        <h1>Login</h1>
        <asp:TextBox ID="txtCode"  runat="server" type ="text" name="" placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="txtpwd"  runat="server" type ="Password" name="" placeholder="Password"></asp:TextBox>
        <asp:Button ID="btnlogin" runat="server" Text="Button" type ="submit" name="" value="Login" OnClick="btnlogin_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
