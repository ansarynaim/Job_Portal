<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekersModule/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeeker_Registration.aspx.cs" Inherits="JobPortal.JobSeekersModule.JobSeeker_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Name:</td>
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
            <td>Job Profile :</td>
            <td>
                <asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
                
        </tr>


        <tr>
            <td>Job Experience :</td>
            <td>
                <asp:DropDownList ID="ddlexp" runat="server">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList></td>

        </tr>


        <tr>
            <td>Qualification :</td>
            <td>
                <asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>

        </tr>


        <tr>
            <td>Country:</td>
            <td>
                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>

        </tr>


        <tr>
            <td>State:</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>

        </tr>


        <tr>
            <td>City:</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>

        </tr>

        <tr>
            <td>Photo Upload:</td>
            <td>
                <asp:FileUpload ID="fuphoto" runat="server" /></td>

        </tr>

        <tr>
            <td>Resume Upload:</td>
            <td>
                <asp:FileUpload ID="furesume" runat="server" /></td>

        </tr>

        <tr>
            <td>Comment:</td>
            <td>
                <asp:TextBox ID="txtcomments" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>

    </table>
</asp:Content>
