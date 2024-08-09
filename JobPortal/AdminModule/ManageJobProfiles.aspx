<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobProfiles.aspx.cs" Inherits="JobPortal.AdminModule.ManageJobProfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Job Profile Name:</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>

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
                <asp:GridView ID="gvjobprofiles" runat="server" AutoGenerateColumns="False" 
                    OnRowCommand="gvjobprofiles_RowCommand" CellPadding="4" ForeColor="#333333" 
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="JobProfile ID">
                            <ItemTemplate>
                                <%#Eval("jpid") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="JobProfile Name">
                            <ItemTemplate>
                                <%#Eval("jpname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" ForeColor="#660033" BackColor="White" Width="70px" Height="25px" CommandName="A" CommandArgument='<%#Eval("jpid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" ForeColor="#660033" BackColor="White"
                                    Width="70px" Height="25px" CommandName="B" CommandArgument='<%#Eval("jpid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
