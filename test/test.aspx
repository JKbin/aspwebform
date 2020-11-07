<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="ProjectWebForm.test.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        select a file to upload : <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="UploadButton" runat="server" OnClick="UploadButton_Click" Text="Upload file" />
        <hr />
        <asp:Label ID="UploadStatusLabel" runat="server">
        </asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Label ID="lblMessaga" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
