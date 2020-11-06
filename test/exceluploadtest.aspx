<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exceluploadtest.aspx.cs" Inherits="ProjectWebForm.test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>


<body>
    <form id="form1" runat="server">

        <asp:DataGrid ID="DataGrid1" runat="server" GridLines="Vertical" CellPadding="3" BackColor="White"
            BorderColor="#999999" BorderWidth="1px" BorderStyle="None" Width="100%" Height="100%" Font-Size="X-Small"
            Font-Names="Verdana">
            <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
            <AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
            <ItemStyle BorderWidth="2px" ForeColor="Black" BorderStyle="Solid" BorderColor="Black" BackColor="#EEEEEE"></ItemStyle>
            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px" ForeColor="White" BorderStyle="Solid"
                BorderColor="Black" BackColor="#000084"></HeaderStyle>
            <FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
            <PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>

        <asp:FileUpload ID="FileUploadToServer" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No record found!">
        </asp:GridView>
        <asp:Button ID="btndownload" runat="server" Text="Download File" OnClick="btndownload_Click" />
    </form>
</body>
</html>
