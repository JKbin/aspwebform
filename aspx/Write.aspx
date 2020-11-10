<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="ProjectWebForm.aspx.Board.Write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        form section section {
            margin-left: 760px;
        }

        h3 {
            text-decoration: underline;
        }

        section div div {
            border-style: solid;
            border-color: #FFFFFF;
            border-top-width: 40px;
        }
    </style>
    <section>
        <div>
            <h3>글 쓰기</h3>

        </div>

        <section class="container">
            <table class="table table-hover">
            <tr>
                <th>작성자</th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
            </tr>
            <tr>
                <th>제목</th>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <th>내용</th>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Columns="20" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>비밀번호</th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnWrite" runat="server" Text="저장" OnClick="btnWrite_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-outline-primary" />
        </section>
    </section>
</asp:Content>
