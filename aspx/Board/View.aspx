<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ProjectWebForm.aspx.Board.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

    <h3>글 보기</h3>

    제목 :<asp:Label ID="lblTitle" runat="server"></asp:Label><br />
    번호 :<asp:Label ID="lblNum" runat="server"></asp:Label><br />
    작성자 :<asp:Label ID="lblName" runat="server"></asp:Label><br />
    <%--이메일 :<asp:Label ID="lblEmail" runat="server"></asp:Label><br />
    홈페이지 :<asp:Label ID="lblHomepage" runat="server"></asp:Label><br />--%>
    작성일 :<asp:Label ID="lblPostDate" runat="server"></asp:Label> <br />
    조회수 :<asp:Label ID="lblReadCount" runat="server"></asp:Label><br />
    <%--IP주소 :<asp:Label ID="lblPostIP" runat="server"></asp:Label> <br />--%>
    <asp:Label ID="lblContent" runat="server"></asp:Label><br />
    <asp:Button ID="btnModify" runat="server" Text="수정" onclick="btnModify_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="삭제" onclick="btnDelete_Click" />
    <asp:Button ID="btnList" runat="server" Text="리스트" onclick="btnList_Click" />
</div>


</asp:Content>
