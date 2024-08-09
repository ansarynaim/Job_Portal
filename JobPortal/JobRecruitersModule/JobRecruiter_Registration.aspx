<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruitersModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_Registration.aspx.cs" Inherits="JobPortal.JobRecruitersModule.JobRecruiter_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>

        <tr>
            <td>Company Type :</td>
            <td>
                <asp:DropDownList ID="ddlcompanytype" runat="server"></asp:DropDownList></td>

        </tr>

        <tr>
            <td>Company Name:</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Contact Person:</td>
            <td>
                <asp:TextBox ID="txtcontactperson" runat="server"></asp:TextBox></td>
        </tr>


        <tr>
            <td>Contact Number:</td>
            <td>
                <asp:TextBox ID="txtcontactnumber" runat="server"></asp:TextBox></td>
        </tr>


        <tr>
            <td>Comment:</td>
            <td>
                <asp:TextBox ID="txtcomments" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>

    </table>
</asp:Content>
