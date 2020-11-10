<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="ProjectWebForm.aspx.Board.Modify" %>

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
            <h3>글 수정</h3>
        </div>

        <section class="container">
            <table class="table table-hover">
                <tr>
                    <th>번호</th>
                    <td>
                        <asp:Label ID="lblNum" runat="server" Text="" />
                    </td>
                </tr>

                <tr>
                    <td>작성자</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>제목</td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>내용</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Columns="20" Rows="5" />
                    </td>
                </tr>

                <tr>
                    <td>비밀번호</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnModify" runat="server" Text="수정" OnClick="btnModify_Click" CssClass="btn btn-outline-secondary" />
            <asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-outline-info" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </section>
    </section>
</asp:Content>
