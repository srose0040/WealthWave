<%@ Page Language="C#" Title="Forgot Password" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BankApplication1.ForgotPassword" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">

    <%-- CREATE HTML TO HANDLE THEM FORGETTING PASSWORD OR REMOVE THIS PAGE --%>
    <!-- Submit Button -->
<asp:Button Text="Change Password" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="PasswordButton_Click" />

</asp:Content>