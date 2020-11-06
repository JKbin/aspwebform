<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logintest.aspx.cs" Inherits="ProjectWebForm.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
            <asp:TextBox ID="txtpwd" runat="server"></asp:TextBox>
            <asp:Button ID="btnlogin" runat="server" Text="login" OnClick="btnlogin_Click" />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>

        <div>
        </div>
    </form>
</body>
</html>
