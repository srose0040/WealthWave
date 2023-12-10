<%@ Page Language="C#" Title="WealthWave Login Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="BankApplication1.LogInPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group "  style="margin-top: 100px;">
          <h3>Welcome to WealthWave Bank</h3>
    </div>
    <!--For user name and passwordss-->
<div class="form-group "  style="margin-top: 50px;">
    <label for="username">Username:</label>
    <asp:TextBox ID="username" runat="server" CssClass="form-control" />
</div>

<div class="form-group" style="margin-top: 50px;">
    <label for="password">Password:</label>
    <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" />
</div>
    <div style="margin-top: 50px;">
        <asp:Button Text="Login" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="SubmitButton_Click" />

    </div>
<div class="form-group text-center" style="margin-top: 50px;">
    <p>
        <!--This must need to redirect users to passwrd and regsr pages-->
        <asp:HyperLink ID="passwordHPRLink" NavigateUrl="ForgotPassword.aspx" Text="Forgot Password?" runat="server" />
        <asp:HyperLink ID="registrationHPRLink" NavigateUrl="RegistrationForm.aspx" Text="Register" runat="server" />

    </p>
</div>
</asp:Content>

