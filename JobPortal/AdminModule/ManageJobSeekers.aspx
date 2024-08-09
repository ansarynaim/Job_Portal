<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobSeekers.aspx.cs" Inherits="JobPortal.AdminModule.ManageJobSeekers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvjobseekers" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="gvjobseekers_RowCommand" CellPadding="4" ForeColor="#333333"
                    GridLines="None">
                    <alternatingrowstyle backcolor="White" />
                    <columns>
                        <asp:TemplateField HeaderText="ID">
                            <itemtemplate>
                                <%#Eval("jsid") %>
                            </itemtemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <itemtemplate>
                                <%#Eval("jsname") %>
                            </itemtemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EmailId">
                            <ItemTemplate>
                                <%#Eval("jsemail") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Profile">
                            <ItemTemplate>
                                <%#Eval("jpname") %> (<%#Eval("jsexp") %> Years)
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate>
                                <%#Eval("qname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="JobSeeker Address">
                            <ItemTemplate>
                                <%#Eval("cityname") %> ,  <%#Eval("sname") %> ,  <%#Eval("cname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                                <%#Eval("jsphoto") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Resume">
                            <ItemTemplate>
                                <%#Eval("jsresume") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <%#Eval("jscomments") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                                <%#Eval("jsinserted_date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("jsstatus") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text='<%#Eval("jsstatus").ToString()== "0" ? "Active" : "InActive" %>'
                                    ForeColor="#660033" BackColor="White"
                                    Width="70px" Height="25px" CommandName="A" CommandArgument='<%#Eval("jsid") %>' />
                            </ItemTemplate>
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
