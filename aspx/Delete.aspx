<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ProjectWebForm.aspx.Board.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div section div {
            margin-left: 410px;
        }

        div div h3 {
            margin-bottom: 80px;
        }
    </style>
    <div>
        <div>
            <h3>글 삭제</h3>
        </div>

        <section class="container">
            <table class="table table-borderless">
                <tr>
                    <td>
                        <asp:Label ID="lblNum" runat="server" ForeColor="Red" />번 글을 삭제하시겠습니까?
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="암호 : "></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" />

                    </td>
                </tr>
            </table>
        </section>

        <section>
            <div>
                <asp:Button ID="Button1" runat="server" Text="삭제" OnClientClick ="return confirm('정말로 삭제하시겠습니까?');" OnClick="btnDelete_Click" CssClass="btn btn-primary"/>
                <asp:Button ID="Button2" runat="server" Text="취소" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            </div>

        </section>















        <%--<asp:Label ID="lblNum" runat="server" ForeColor="Red" />
        번 글을 삭제하시겠습니까?<br />--%>

        <%--<asp:Label ID="Label1" runat="server" Text="암호 : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" />--%>

        <%-- <asp:Button ID="btnDelete" runat="server" Text="삭제" OnClientClick="return confirm('정말로 삭제?');" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="취소" OnClick="btnCancel_Click" Style="height: 21px" /><br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" />--%>
    </div>

</asp:Content>
