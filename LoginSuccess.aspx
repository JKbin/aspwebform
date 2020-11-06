<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSuccess.aspx.cs" Inherits="ProjectWebForm.LoginSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login Success</h1>
            <asp:Label ID="txtuser" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnlogout" runat="server" Text="Logout" OnClick="btnlogout_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        
        </div>
    </form>
</body>
</html>
