<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="ProjectWebForm.aspx.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>test</h1>

    <div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"   
  
OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">  
            <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                
                <asp:TemplateField HeaderText="회사명">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_COMP_NM" runat="server" Text='<%#Eval("COMP_NM") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="공장명">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_PLANT_NM" runat="server" Text='<%#Eval("PLANT_NM") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="품번">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_PART_NO" runat="server" Text='<%#Eval("PART_NO") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="품명">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_PART_NM" runat="server" Text='<%#Eval("PART_NM") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="단위">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_UNIT" runat="server" Text='<%#Eval("UNIT") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="수량">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_BUY_QTY" runat="server" Text='<%#Eval("BUY_QTY") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_BUY_QTY" runat="server" Text='<%#Eval("BUY_QTY") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="인덱스">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_DETAIL_LINE" runat="server" Text='<%#Eval("DETAIL_LINE") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  

                <asp:TemplateField HeaderText="주문번호">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_BUY_ORD_NO" runat="server" Text='<%#Eval("BUY_ORD_NO") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  


                <asp:TemplateField HeaderText="거래처명">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_CUSTOMER_NAME" runat="server" Text='<%#Eval("CUSTOMER_NAME") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  



            </Columns>  


            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView>  
    </div>















</asp:Content>
