<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BankApplication1.HomePage" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
<div style="margin-bottom: 50px; margin-top: 20px;">
     <!-- Display the account holder's name -->
        <div class="text-left" style="margin-bottom: 20px; margin-top: 20px;">
            <h3>
                <asp:Label ID="lblAccountHolder" runat="server" CssClass="account-holder-label"></asp:Label>
            </h3>
     <!-- Display a welcome message and user's first and last name -->      
            <div style="margin-bottom: 20px; margin-top: 20px;">
                <h4>
                    <asp:Label ID="WelcomeLabel" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblFirstName" runat="server" CssClass="label-value" Visible="false"></asp:Label>
                    <asp:Label ID="lblLastName" runat="server" CssClass="label-value" Visible="false"></asp:Label>
                </h4>
            </div>
        </div>
     <!-- Display the account number retrieved from the session -->
        <h4>
            Account Number: <%= Session["CustomerId"] %>
        </h4>
    </div>
    <!--Additional options for users-->
    <div class="bodyTitles" style="margin-bottom: 20px;">
        <h3>Choose an account type:</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Savings Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ChequingAccount.aspx" Text="Chequing Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="LoanAccount.aspx" Text="Loan Account" runat="server" /></li>
        </ul>
    </div>

    <div class="bodyTitles" style="margin-bottom: 100px;">
        <h3>Additional Options</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li><a href="ContactAndSupport.aspx" target="_blank" id="TermsAndConditions">Contact and Support</a></li>
        </ul>
    </div>
    <!-- Navigation links -->
<div class="bodyTitles" style="position: absolute; top: 200px; right: 250px;">
        <h3>Go To:</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="StartPage.aspx" Text="Home Page" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="AccountDetails.aspx" Text="Account Details" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Deposit to Savings" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ChequingAccount.aspx" Text="Deposit to Chequings" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="LoanAccount.aspx" Text="Pay off your Loan" runat="server" /></li>
        </ul>
    </div>

    <!-- Fancy buttons container -->
    <div class="fancy-buttons-container" style="margin-bottom: 30px; margin-top: 50px;">
        <asp:Button ID="btnAccountDetails" runat="server" CssClass="fancy-button primary-button" Text="Account Details" OnClick="AccountDetails_Click" />
        <asp:Button ID="btnLogout" runat="server" CssClass="fancy-button primary-button" Text="Log Out" OnClick="LogoutButton_Click" />
    </div>



</asp:Content>