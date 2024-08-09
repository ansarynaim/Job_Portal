<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruitersModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_JobPostList.aspx.cs" Inherits="JobPortal.JobRecruitersModule.JobRecruiter_JobPostList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="gvjobpostlist" runat="server" OnRowCommand="gvjobpostlist_RowCommand" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="JobPost Id">
                            <ItemTemplate>
                                <%#Eval("jpsid") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Recruiter">
                            <ItemTemplate>
                                <%#Eval("jrname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Profile">
                            <ItemTemplate>
                                <%#Eval("jpname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("jpsgender").ToString()=="1" ? "Male" : Eval("jpsgender").ToString()=="2" ? "Female" : "Both"%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Required Experience">
                            <ItemTemplate>
                                <%#Eval("jpsminexp") %> - <%#Eval("jpsmaxexp")  %> Years
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Offered Salary">
                            <ItemTemplate>
                                <%#Eval("jpsminsalary") %> Rs. - <%#Eval("jpsmaxsalary") %> Rs.
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <%#Eval("jpscomments") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                                <%#Eval("jpsinserted_date") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("jpsstatus") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text='<%#Eval("jpsstatus").ToString()=="0" ? "Active" : "InActive" %>' CommandName="A"
                                    CommandArgument='<%#Eval("jpsid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit"
                                    CommandName="B"
                                    CommandArgument='<%#Eval("jpsid")%>' />
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
