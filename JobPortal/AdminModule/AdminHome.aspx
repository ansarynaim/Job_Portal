<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="JobPortal.AdminModule.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Admin Name:</td>
            <td><asp:Label ID="lbladminname" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Admin Email:</td>
            <td>
                <asp:Label ID="lbladminemail" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Admin Password:</td>
            <td>
                <asp:Label ID="lbladminpassword" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
