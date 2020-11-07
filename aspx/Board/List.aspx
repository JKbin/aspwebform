﻿<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ProjectWebForm.aspx.Board.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        게시판 리스트<br />

        <br />

        <asp:GridView ID="ctlBasicList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-scripted">
            <Columns>
                <asp:BoundField HeaderText="번호" DataField="Num" />
                <asp:HyperLinkField HeaderText="제목" DataNavigateUrlFields="Num"
                    DataNavigateUrlFormatString="View.aspx?Num={0}"
                    DataTextField="Title" ItemStyle-Width="350px" />
                <asp:BoundField HeaderText="작성자" DataField="Name" />
                <asp:BoundField HeaderText="작성일" DataField="PostDate" DataFormatString="{0:yyyy-mm-dd}" />
                <asp:BoundField HeaderText="조회수" DataField="ReadCount" />
            </Columns>
        </asp:GridView>

        <asp:DropDownList ID="lstSearchField" runat="server">
            <asp:ListItem Value="Name">이름</asp:ListItem>
            <asp:ListItem Value="Title" Selected="True">제목</asp:ListItem>
            <asp:ListItem Value="Content">내용</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="txtSearchQuery" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="검색" OnClick="btnSearch_Click" /><br />
        <asp:Button ID="btnWrite" runat="server" Text="글쓰기" OnClick="btnWrite_Click" />

    </div>
</asp:Content>
