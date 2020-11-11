<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="listtest1.aspx.cs" Inherits="ProjectWebForm.aspx.listtest1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <section id="form1" runat="server">

            <h3>CheckBox CheckedChanged Example</h3>

            Select whether to include tax in the subtotal.

      <br />
            <br />

            <table border="1" >

                <tr>

                    <th colspan="2">Shopping cart

                    </th>

                </tr>

                <tr>

                    <td>Item 1

                    </td>

                    <td>$1.99

                    </td>

                </tr>

                <tr>

                    <td>Item 2

                    </td>

                    <td>$2.99

                    </td>

                </tr>

                <tr>

                    <td>Item 3

                    </td>

                    <td>$3.99

                    </td>

                </tr>

                <tr>

                    <td>

                        <b>Subtotal</b>

                    </td>

                    <td>

                        <asp:Label ID="Message" runat="server" />

                    </td>

                </tr>

                <tr>

                    <td colspan="2">

                        <asp:CheckBox ID="checkbox1" runat="server"
                            AutoPostBack="True"
                            Text="Include 8.6% sales tax"
                            TextAlign="Right"
                            OnCheckedChanged="Check_Clicked" />

                    </td>

                </tr>

            </table>

        </section>
    </div>



</asp:Content>
