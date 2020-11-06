<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="ProjectWebForm.aspx.list" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>발주서 리스트 페이지</h1>
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
            <asp:Button ID="btnSearch" runat="server" Text="검색" CssClass="btn btn-dark"/>
        </div>
</asp:Content>
