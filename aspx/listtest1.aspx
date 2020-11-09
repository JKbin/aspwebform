<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="listtest1.aspx.cs" Inherits="ProjectWebForm.aspx.listtest1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-hover table-scripted" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridview_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ordcheck" runat="server" Width="5px"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="회사명" DataField="COMP_NM" />
                <asp:BoundField HeaderText="공장명" DataField="PLANT_NM" />
                <asp:BoundField HeaderText="품번" DataField="PART_NO" />
                <asp:BoundField HeaderText="품명" DataField="PART_NM" />
                <asp:BoundField HeaderText="단위" DataField="UNIT" />
                <asp:BoundField HeaderText="수량" DataField="BUY_QTY" />
                <asp:HyperLinkField HeaderText="주문번호" DataNavigateUrlFields="CUSTOMER_NAME"
                    DataNavigateUrlFormatString="detail.aspx?CUSTOMER_NAME={0}"
                    DataTextField="BUY_ORD_NO" />
                <asp:BoundField HeaderText="거래처명" DataField="CUSTOMER_NAME" />
            </Columns>
        </asp:GridView>
    </div>

    <%--<section>
        <nav aria-label="Page navigation example">
            <ul class="pagination">
                <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                <li class="page-item"><a class="page-link" href="#">1</a></li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
                <li class="page-item"><a class="page-link" href="#">Next</a></li>
            </ul>
            <asp:DropDownList ID="lstSearchField" runat="server">
                <asp:ListItem Value="BUY_REQ_NO" Selected="True">요청번호</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtSearchQuery" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="검색" CssClass="btn btn-dark" />
        </nav>
    </section>--%>
   





</asp:Content>
