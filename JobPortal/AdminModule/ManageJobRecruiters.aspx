<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobRecruiters.aspx.cs" Inherits="JobPortal.AdminModule.ManageJobRecruiters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvjobrecruiters" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="gvjobrecruiters_RowCommand" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <%#Eval("jrid") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company Type">
                            <ItemTemplate>
                                <%#Eval("jrcompanytype") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("jrname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EmailId">
                            <ItemTemplate>
                                <%#Eval("jremail") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Password">
                            <ItemTemplate>
                                <%#Eval("jrpassword") %> 
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contact Person">
                            <ItemTemplate>
                                <%#Eval("jrcontactperson") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Contact Number">
                            <ItemTemplate>
                                <%#Eval("jrcontactnumber") %> 
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <%#Eval("jrcomments") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                                <%#Eval("jrinserted_date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("jrstatus") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text='<%#Eval("jrstatus").ToString()== "0" ? "Active" : "InActive" %>' ForeColor="#660033" BackColor="White"
                                    Width="70px" Height="25px" CommandName="A" CommandArgument='<%#Eval("jrid") %>' />
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
