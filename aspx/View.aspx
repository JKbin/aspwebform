<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ProjectWebForm.aspx.Board.View" %>

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
            <h3>글 보기</h3>
        </div>

        <section class="container">
            <table class="table table-hover">
                <tr>
                    <th>제목</th>
                    <td>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>번호</td>
                    <td>
                        <asp:Label ID="lblNum" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>작성자</td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>작성일</td>
                    <td>
                        <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>조회수</td>
                    <td>
                        <asp:Label ID="lblReadCount" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>내용</td>
                    <td>
                        <asp:Label ID="lblContent" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <asp:Button ID="btnModify" runat="server" Text="수정" OnClick="btnModify_Click" CssClass="btn btn-outline-primary" />
            <asp:Button ID="btnDelete" runat="server" Text="삭제" OnClick="btnDelete_Click" CssClass="btn btn-outline-danger" />
            <asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-outline-info" />
        </section>
    </section>
</asp:Content>
