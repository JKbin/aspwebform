<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ProjectWebForm.aspx.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        form div section {
            text-align: center
        }

        tbody tr th {
            text-align: center;
        }

        tbody tr td {
            text-align: center;
        }

        div div h3 {
            margin-bottom: 80px;
        }
    </style>
    <div>
        <div>
            <h3>검색 리스트</h3>

        </div>

        <section>
            <asp:GridView ID="ctlSearchList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-scripted">
                <Columns>
                    <asp:BoundField HeaderText="번호" DataField="Num" />
                    <asp:HyperLinkField HeaderText="제목" DataNavigateUrlFields="Num" DataNavigateUrlFormatString="View.aspx?Num={0}"
                        DataTextField="Title" ItemStyle-Width="350px" />
                    <asp:BoundField HeaderText="작성자" DataField="Name" />
                    <asp:BoundField HeaderText="작성일" DataField="PostDate" DataFormatString="{0:yyyy-mm-dd}" />
                    <asp:BoundField HeaderText="조회수" DataField="ReadCount" />
                </Columns>
            </asp:GridView>

            <section>
                <asp:Button ID="btnList" runat="server" Text="검색 종료" OnClick="btnList_Click" CssClass="btn btn-primary" />
            </section>
        </section>


    </div>
</asp:Content>
