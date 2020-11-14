<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="ordlist.aspx.cs" Inherits="ProjectWebForm.aspx.list" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div.container {
            margin-left: 0px
        }

        #ContentPlaceHolder1_lblCustomerNM {
            margin-left: 30px;
        }

        form div h2 {
            margin-top: 40px;
        }

        div.container {
            margin-top: 50px;
        }

        tbody tr th {
            text-align: center;
        }

        tbody tr td {
            text-align: center;
        }
    </style>

    <div class="container">
        <h2>발주서 리스트 페이지<asp:Label ID="lblCustomerNM" runat="server"></asp:Label>
            <asp:Button ID="btnSearch" runat="server" Text="조회" CssClass="btn btn-primary" OnClick="btnSearch_Click" /></h2>
    </div>

    <div class="container">
        <%--AllowPaging/PageSize/OnPageIndexChanging : 페이징처리--%>
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-hover table-scripted"
            AutoGenerateEditButton="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridview_PageIndexChanging"
            OnRowEditing="gridview_RowEditing" OnRowCancelingEdit="gridview_RowCancelingEdit"
            OnRowUpdating="gridview_RowUpdating" DataKeyNames="DETAIL_LINE" HeaderStyle-BackColor="#507CD1">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ordcheck" runat="server" Width="5px" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="회사명" DataField="COMP_NM" />
                <asp:BoundField HeaderText="공장명" DataField="PLANT_NM" />
                <asp:BoundField HeaderText="품번" DataField="PART_NO" />
                <asp:BoundField HeaderText="품명" DataField="PART_NM" />
                <asp:BoundField HeaderText="단위" DataField="UNIT" />
                <asp:BoundField HeaderText="수량" DataField="BUY_QTY" />
                <asp:BoundField HeaderText="인덱스" DataField="DETAIL_LINE" />
                <asp:BoundField HeaderText="주문번호" DataField="BUY_ORD_NO" />
                <asp:BoundField HeaderText="거래처명" DataField="CUSTOMER_NAME" />
            </Columns>
        </asp:GridView>

        <div class="btntxt">
            <asp:Button ID="btnsubmit" runat="server" Text="발행" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
            <hr />
            <asp:PlaceHolder ID="plBarCode" runat="server" />
        </div>
    </div>

    <div class="container">
        <div>
            <h2>
                <asp:Label ID="Label1" runat="server" Text="거래명세서"></asp:Label></h2>
        </div>
        <asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-hover table-scripted" AllowPaging="true" PageSize="5"
            OnPageIndexChanging="gridview2_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="DETAIL_LINE" DataField="DETAIL_LINE" />
                <asp:BoundField HeaderText="BUY_ORD_NO" DataField="BUY_ORD_NO" />
                <asp:BoundField HeaderText="QTY" DataField="QTY" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
