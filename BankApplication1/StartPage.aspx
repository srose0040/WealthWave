<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="BankApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<main>

    <div class="text-center">
        <h1 class="display-4">Welcome To The Wealth Wave Bank </h1>
        <p> Please Click on the Login button </p>

        <!--This button will redirect user into login page we may have to change it in future -->
            <div id="submitButton1">
                <asp:Button Text="Login" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="LoginButton_Click" />
            </div>

    </div>
</main>

</asp:Content>
