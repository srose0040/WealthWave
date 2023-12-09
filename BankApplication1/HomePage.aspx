<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BankApplication1.HomePage" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>(WE WILL CHANGE THIS BY USER NAME)Dashboard</h3>
        <p>User Account Number: @Model.ViewModel.UserAccountNumber</p>
     </div>
<div class="bodyTitles">
    <p>Choose an account type:</p>
    <ul>
        <li><a asp-page="/SavingAccount">Savings Account</a></li>
        <li><a asp-page="/CheckingAccount">Checking Account</a></li>
        <li><a asp-page="/LoanAccount">Loan Account</a></li>
    </ul>
</div>


    <!--Additional options for users-->
<div class ="bodyTitles">
        <h3>Additional Options</h3>
        <ul>
        <li><a asp-page="/SettingAndPrivacy">Setting and Privacy</a></li>
        <li><a asp-page="/ContactSupport">Contact and Support</a></li>
        </ul>
    </div>
<div class="bodyTitles" style="position: fixed; top: 300px; right: 100px;">
    <ul>
        <li><a asp-page="/Index">Home</a></li>
        <li><a asp-page="/AccountDetails">Account</a></li>
        <li><a asp-page="TransactionsHistory">Transaction</a></li>
        <li><a asp-page="/Deposit">Deposit</a></li>
        <li><a asp-page="/SavingAccount">Savings</a></li>
    </ul>
</div>
</asp:Content>