<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ProjectWebForm.aspx.Board.Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <h3>글 삭제</h3>

        <asp:Label ID="lblNum" runat="server" ForeColor="Red" />
        번 글을 삭제하시겠습니까?<br />

        <asp:Label ID="Label1" runat="server" Text="암호 : "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" />

        <asp:Button ID="btnDelete" runat="server" Text="삭제" OnClientClick="return confirm('정말로 삭제?');" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="취소" OnClick="btnCancel_Click" Style="height: 21px" /><br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" />

    </div>

</asp:Content>
