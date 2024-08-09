<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruitersModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_JobPost.aspx.cs" Inherits="JobPortal.JobRecruitersModule.JobRecruiter_JobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Job Profile: </td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>Preferred Gender :</td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>

        </tr>

        <tr>
            <td> Min Exp Required :</td>
            <td>
                <asp:DropDownList ID="ddlminexp" runat="server">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList></td>

        </tr>

        <tr>
            <td>Max Exp Required :</td>
            <td>
                <asp:DropDownList ID="ddlmaxexp" runat="server">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                </asp:DropDownList></td>

        </tr>

        <tr>
            <td>Minumum Salary Offer : </td>
            <td>
                <asp:TextBox ID="txtminsalary" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Maximum Salary Offer : </td>
            <td>
                <asp:TextBox ID="txtmaxsalary" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Comments : </td>
            <td>
                <asp:TextBox ID="txtcomments" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnjobpost" runat="server" Text="Job Post" OnClick="btnjobpost_Click" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>


    </table>
</asp:Content>
