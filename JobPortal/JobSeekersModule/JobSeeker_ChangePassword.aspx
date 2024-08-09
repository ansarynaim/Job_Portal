<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekersModule/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeeker_ChangePassword.aspx.cs" Inherits="JobPortal.JobSeekersModule.JobSeeker_ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>

        <tr>
            <td>Current Password:</td>
            <td>
                <asp:TextBox ID="txtcurrentpassword" runat="server"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Confirm New Password:</td>
            <td>
                <asp:TextBox ID="txtconfirmnewpassword" runat="server"></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnchangepassword" runat="server" Text="Change Password" OnClick="btnchangepassword_Click" />
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
