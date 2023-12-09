<%@ Page Language="C#" Title="WealthWave Login Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="BankApplication1.LogInPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--For user name and passwordss-->
<div class="form-group">
    <label for="username">Username:</label>
    <input type="text" id="username" name="username" class="form-control" runat="server" asp-for="Login.Username" required />
</div>

<div class="form-group">
    <label for="password">Password:</label>
    <input type="password" id="password" name="password" class="form-control" runat="server" asp-for="Login.Password" required />
</div>

     <asp:Button Text="Login" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="SubmitButton_Click" />

<div class="form-group text-center">
    <p>
        <!--This must need to redirect users to passwrd and regsr pages-->
        <asp:HyperLink ID="passwordHPRLink" NavigateUrl="ForgotPassword.aspx" Text="Forgot Password?" runat="server" />
        <asp:HyperLink ID="registrationHPRLink" NavigateUrl="RegistrationForm.aspx" Text="Register" runat="server" />

    </p>
</div>
</asp:Content>

