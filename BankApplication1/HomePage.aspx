<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BankApplication1.HomePage" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>(WE WILL CHANGE THIS BY USER NAME)Dashboard</h3>
        <p>User Account Number: @Model.ViewModel.UserAccountNumber</p>
    </div>
    <div class="bodyTitles">
        <p>Choose an account type:</p>
        <ul>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Savings Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="CheckingAccount.aspx" Text="Checking Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="LoanAccount.aspx" Text="Loan Account" runat="server" /></li>
        </ul>
    </div>
    
    
    <!--Additional options for users-->
    <div class ="bodyTitles">
        <h3>Additional Options</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ContactSupport.aspx" Text="Contact and Support" runat="server" /></li>
        </ul>
    </div>
    <div class="bodyTitles" style="position: fixed; top: 300px; right: 100px;">
        <ul>
            <li><asp:HyperLink NavigateUrl="StartPage.aspx" Text="Home" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="AccountDetails.aspx" Text="Account" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="TransactionsHistory.aspx" Text="Transaction" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="Deposit.aspx" Text="Deposit" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Savings" runat="server" /></li>
        </ul>
    </div>
</asp:Content>