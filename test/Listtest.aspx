<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listtest.aspx.cs" Inherits="ProjectWebForm.test.Listtest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <title></title>
</head>

<body>
    <h1>게시판 리스트 테스트1</h1>
    <form id="form1" runat="server">
        <div class="container">

            <asp:GridView ID="ctlBasicList" runat="server" AutoGenerateColumns="false" 
                CssClass="table table-bordered table-hover table-scripted">
                <Columns>
                    <asp:BoundField HeaderText="회사명" DataField="COMP_NM" />
                    <asp:HyperLinkField HeaderText="요청번호" DataNavigateUrlFields="COMP_NM" 
                        DataNavigateUrlFormatString="detail.aspx?COMP_NM={0}"
                        DataTextField="BUY_REQ_NO" />
                    <asp:BoundField HeaderText="전화" DataField="COMP_TEL" />
                    <asp:BoundField HeaderText="팩스" DataField="COMP_FAX" />
                    <asp:BoundField HeaderText="현장명" DataField="PLANT_NM" />
                    <asp:BoundField HeaderText="요청자" DataField="USER_NM" />
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="lnkWrite" runat="server" CssClass="btn btn-primary">글쓰기</asp:HyperLink>
            <asp:DropDownList ID="lstSearchField" runat="server">
                <asp:ListItem Value="BUY_REQ_NO" Selected="True">요청번호</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtSearchQuery" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="검색" CssClass="btn btn-dark" OnClick="btnSearch_Click" />
        </div>
        
        
    </form>
</body>
</html>
