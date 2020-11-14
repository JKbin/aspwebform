<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ProjectWebForm.aspx.Board.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        form div section {
            margin-top: 80px;
        }

        div section section {
            padding-left: 700px;
        }

        tbody tr th {
            text-align: center;
        }

        tbody tr td {
            text-align: center;
        }

        div div h3 {
            margin-top: 50px;
        }
    </style>
    <div>
        <div>
            <h3>공용 게시판 리스트</h3>
        </div>

        <section>
            <asp:GridView ID="ctlBasicList" runat="server" AutoGenerateColumns="false"
                CssClass="table table-bordered table-hover table-scripted">
                <Columns>
                    <asp:BoundField HeaderText="번호" DataField="Num" />
                    <asp:HyperLinkField HeaderText="제목" DataNavigateUrlFields="Num"
                        DataNavigateUrlFormatString="View.aspx?Num={0}"
                        DataTextField="Title" ItemStyle-Width="350px" />
                    <asp:BoundField HeaderText="작성자" DataField="Name" />
                    <asp:BoundField HeaderText="작성일" DataField="PostDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                    <asp:BoundField HeaderText="조회수" DataField="ReadCount" />
                </Columns>
            </asp:GridView>



            <section>
                <asp:DropDownList ID="lstSearchField" runat="server">
                    <asp:ListItem Value="Name">작성자</asp:ListItem>
                    <asp:ListItem Value="Title" Selected="True">제목</asp:ListItem>
                    <asp:ListItem Value="Content">내용</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSearchQuery" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="검색" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnWrite" runat="server" Text="글쓰기" OnClick="btnWrite_Click" CssClass="btn btn-info" />
            </section>
        </section>
    </div>
</asp:Content>
