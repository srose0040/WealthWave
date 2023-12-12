<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BankApplication1.HomePage" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-bottom: 100px; margin-top: 100px;">
       <div class="text-left" style="margin-bottom: 75px; margin-top: 75px;">
            <h3>
                <asp:Label ID="lblAccountHolder" runat="server" CssClass="account-holder-label"></asp:Label>
            </h3>
       
         <div style="margin-bottom: 100px; margin-top: 100px;">
             <h4>
                <asp:Label ID="WelcomeLabel" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblFirstName" runat="server" CssClass="label-value"></asp:Label>
                <asp:Label ID="lblLastName" runat="server" CssClass="label-value"></asp:Label>
             </h4>
        </div>

       </div>
            <h4>
                Account Number:  <%= Session["CustomerId"] %><%= Session["CustomerId"] %>
            </h4>
        </div>

    <div class="bodyTitles">
        <h3>Choose an account type:</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Savings Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ChequingAccount.aspx" Text="Chequing Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="LoanAccount.aspx" Text="Loan Account" runat="server" /></li>
        </ul>
    </div>
    
    
    <!--Additional options for users-->
    <div class ="bodyTitles">
        <h3>Additional Options</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li> <a href="ContactAndSupport.aspx" target="_blank" id="TermsAndConditions">Contact and Support</a></li>
        </ul>
    </div>

<%--    <div class="form-group" style="margin-bottom: 10px; margin-top: 10px;">
        <label for="contactAndSupport">ContactAndSupport</label>
        <a href="ContactAndSupport.aspx" target="_blank" id="TermsAndConditions">Contact and Support</a>
    </div>--%>

    <div class="bodyTitles" style="position: fixed; top: 500px; right: 100px;">
        <ul>
            <li><asp:HyperLink NavigateUrl="StartPage.aspx" Text="Home" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="AccountDetails.aspx" Text="Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="TransactionsHistory.aspx" Text="Transaction" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="Deposit.aspx" Text="Deposit" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Savings" runat="server" /></li>
        </ul>
    </div>

            <!-- image container for page 2 container -->
    <div class="image-container" style="margin-top:auto;">
       <asp:Image ID="image9" runat="server" alt="image9" Width="410" Height="410" ClientIDMode="Static" />
    </div>

<div class="fancy-buttons-container" style="margin-bottom: 200px; margin-top: 200px;">
    <asp:Button ID="btnAccountDetails" runat="server" CssClass="fancy-button primary-button" Text="Account Details" OnClick="AccountDetails_Click" />
    <asp:Button ID="btnLogout" runat ="server" CssClass="fancy-button primary-button" Text="Log Out" OnClick="LogoutButton_Click" />
</div>




</asp:Content>