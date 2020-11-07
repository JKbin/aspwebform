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
            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="제목 :"></asp:Label>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="번호 :"></asp:Label>
                    <asp:Label ID="lblNum" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="작성자 :"></asp:Label>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label4" runat="server" Text="작성일 :"></asp:Label>
                    <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="조회수 :"></asp:Label>
                    <asp:Label ID="lblReadCount" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label6" runat="server" Text="내용 :"></asp:Label>
                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnModify" runat="server" Text="수정" OnClick="btnModify_Click" CssClass="btn btn-outline-primary" />
                    <asp:Button ID="btnDelete" runat="server" Text="삭제" OnClick="btnDelete_Click" CssClass="btn btn-outline-danger" />
                    <asp:Button ID="btnList" runat="server" Text="리스트" OnClick="btnList_Click" CssClass="btn btn-outline-info" />
                </div>
            </div>



        </section>



    </section>





</asp:Content>
