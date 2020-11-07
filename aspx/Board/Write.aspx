<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="ProjectWebForm.aspx.Board.Write" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

   <h3>글 쓰기</h3>

   작성자 :

   <asp:TextBox ID="txtName" runat="server" /><br />

  


  

 
  

   제목 :

   <asp:TextBox ID="txtTitle" runat="server" /><br />

  

   내용 :

   <asp:TextBox ID="txtContent" runat="server"

       TextMode="MultiLine" Columns="20" Rows="5">

   </asp:TextBox><br />


   <br />

  

   비밀번호 :

   <asp:TextBox ID="txtPassword" runat="server"

       TextMode="Password"></asp:TextBox>

   <br />

  

   <asp:Button ID="btnWrite" runat="server" Text="저장"

       onclick="btnWrite_Click" />

   <asp:Button ID="btnList" runat="server" Text="리스트"

       onclick="btnList_Click" />

</div>

</asp:Content>
