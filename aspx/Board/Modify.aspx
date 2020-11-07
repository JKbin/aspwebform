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
        <section>
            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="번호 : "></asp:Label>
                    <asp:Label ID="lblNum" runat="server" Text="" />
                </div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="작성자 : "></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" />
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="제목 : "></asp:Label>
                    <asp:TextBox ID="txtTitle" runat="server" />
                </div>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="내용 : "></asp:Label>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Columns="20" Rows="5" />
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="비밀번호 : "></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnModify" runat="server" Text="수정" OnClick="btnModify_Click" CssClass="btn btn-outline-secondary" />
                    <asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-outline-info" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
                </div>
            </div>
        </section>
    </section>







</asp:Content>
