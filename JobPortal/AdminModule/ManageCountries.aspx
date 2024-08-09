<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCountries.aspx.cs" Inherits="JobPortal.AdminModule.ManageCountries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Country Name:</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" ForeColor="White" BackColor="#660033"
                    Width="70px" Height="25px" OnClick="btnsubmit_Click" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gvcountry" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="gvcountry_RowCommand" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <alternatingrowstyle backcolor="White" />
                    <columns>
                        <asp:TemplateField HeaderText="Country ID">
                            <itemtemplate>
                                <%#Eval("cid") %>
                            </itemtemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Country Name">
                            <itemtemplate>
                                <%#Eval("cname") %>
                            </itemtemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" ForeColor="#660033" BackColor="White"
                                    Width="70px" Height="25px" CommandName="A" CommandArgument='<%#Eval("cid") %>' />
                            </itemtemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <itemtemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" ForeColor="#660033" BackColor="White"
                                    Width="70px" Height="25px" CommandName="B" CommandArgument='<%#Eval("cid") %>' />
                            </itemtemplate>
                        </asp:TemplateField>


                    </columns>
                    <footerstyle backcolor="#990000" font-bold="True" forecolor="White" />
                    <headerstyle backcolor="#990000" font-bold="True" forecolor="White" />
                    <pagerstyle backcolor="#FFCC66" forecolor="#333333" horizontalalign="Center" />
                    <rowstyle backcolor="#FFFBD6" forecolor="#333333" />
                    <selectedrowstyle backcolor="#FFCC66" font-bold="True" forecolor="Navy" />
                    <sortedascendingcellstyle backcolor="#FDF5AC" />
                    <sortedascendingheaderstyle backcolor="#4D0000" />
                    <sorteddescendingcellstyle backcolor="#FCF6C0" />
                    <sorteddescendingheaderstyle backcolor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
