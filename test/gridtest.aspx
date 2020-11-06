<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridtest.aspx.cs" Inherits="ProjectWebForm.gridtest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:TextBox ID="txtserch" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="serch" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
