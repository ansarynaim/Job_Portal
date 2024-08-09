<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruitersModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiterHome.aspx.cs" Inherits="JobPortal.JobRecruitersModule.JobRecruiterHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table>
        <tr>
            <td>Job Recruiter Name:</td>
            <td>
                <asp:Label ID="lbljobrecruitername" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Job Recruiter Email:</td>
            <td>
                <asp:Label ID="lbljobrecruiteremail" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Job Recruiter Password:</td>
            <td>
                <asp:Label ID="lbljobrecruiterpassword" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
