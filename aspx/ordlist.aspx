<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="ordlist.aspx.cs" Inherits="ProjectWebForm.aspx.list" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div.container {
            margin-left: 0px
        }
    </style>
    <h1>발주서 리스트 페이지</h1>

    <div class="container">
        <%--AllowPaging/PageSize/OnPageIndexChanging : 페이징처리--%>
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-hover table-scripted" AllowePaging="true" PageSize="10"
            OnPageIndexChanging="gridview_PageIndexChanging" AutoGenerateEditButton="true" 
            OnRowEditing="gridview_RowEditing" OnRowCancelingEdit="gridview_RowCancelingEdit"
            OnRowUpdating="gridview_RowUpdating" DataKeyNames="DETAIL_LINE">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ordcheck" runat="server" Width="5px"  AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="회사명" DataField="COMP_NM" />
                <asp:BoundField HeaderText="공장명" DataField="PLANT_NM" />
                <asp:BoundField HeaderText="품번" DataField="PART_NO" />
                <asp:BoundField HeaderText="품명" DataField="PART_NM" />
                <asp:BoundField HeaderText="단위" DataField="UNIT" />
                <asp:BoundField HeaderText="수량" DataField="BUY_QTY" />
                <asp:BoundField HeaderText="인덱스" DataField="DETAIL_LINE" />
               <%-- <asp:HyperLinkField HeaderText="주문번호" DataNavigateUrlFields="CUSTOMER_NAME"
                    DataNavigateUrlFormatString="detail.aspx?CUSTOMER_NAME={0}"
                    DataTextField="BUY_ORD_NO" />--%>
                <asp:BoundField HeaderText="주문번호" DataField="BUY_ORD_NO" />
                <asp:BoundField HeaderText="거래처명" DataField="CUSTOMER_NAME" />
            </Columns>
        </asp:GridView>



        <div>
            <asp:Button ID="btnsubmit" runat="server" Text="발행" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
            <asp:Button ID="Button1" runat="server" Text="Test" CssClass="btn btn-danger" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text="Test" CssClass="border-danger"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Test2" OnClick="Button2_Click"/>
            <asp:Label ID="Label2" runat="server" Text="label2"></asp:Label>
        </div>
    </div>
</asp:Content>
