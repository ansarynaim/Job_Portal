<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekersModule/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeekerHome.aspx.cs" Inherits="JobPortal.JobSeekersModule.JobSeekerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Job Seeker Name:</td>
            <td>
                <asp:Label ID="lbljobseekername" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Job Seeker Email:</td>
            <td>
                <asp:Label ID="lbljobseekeremail" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Job Seeeker Password:</td>
            <td>
                <asp:Label ID="lbljobseekerpassword" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
