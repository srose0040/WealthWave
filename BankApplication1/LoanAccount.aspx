<%@ Page Language="C#" Title="Loan Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanAccount.aspx.cs" Inherits="BankApplication1.LoanAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="text-center">
        <h1 class="display-4">Saving Account||Account Number:  <%= Session["CustomerId"] %> </h1>
    </div>

    
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="amount">Amount:</label>
        <asp:TextBox ID="amountTextBox" runat="server" CssClass="form-control" />
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="balance">Balance:</label>
        <asp:TextBox ID="balanceTextBox" runat="server" CssClass="form-control" ReadOnly="true"/>
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="deposit">Deposit:</label>
        <asp:RadioButton ID="depositRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="withdraw">Withdraw:</label>
        <asp:RadioButton ID="withdrawRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>

    <!-- Submit Button -->
<div class="form-group" style="margin-top: 50px;">
    <asp:Button Text="Submit" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="TransactionButton_Click" />
    <asp:Button ID="btnLogout" runat ="server" CssClass="fancy-button primary-button" Text="Log Out" OnClick="LogoutButton_Click" />
</div>

    <!--lbel for Error message-->
<div>
    <asp:Label ID="ShowMessage" runat="server" ForeColor="Black" Text=""></asp:Label>
</div>














<%--   <div class="text-center" style="margin-top: 50px; margin-bottom: 50px;">
 
        <h1 class="display-4">Loan Account [AccountNumber]</h1>
    </div>

    <div class="form-group "  style="margin-top: 100px; margin-bottom: 50px;">
        <label for="lblAccountNumber">Account Number:</label>
    <asp:Label ID="lblAccountNumber" runat="server" Text="123456789" />
    </div>

    <div>
        <label for="lblBalance">Statement Balance:</label>
        <asp:Label ID="lblBalance" runat="server" Text="$1,000.00" />
    </div>
       <div class="bodyTitles" style="position: fixed; top: 300px; right: 100px;">
            <ul>
                <li><asp:HyperLink NavigateUrl="Deposit.aspx" Text="Deposit" runat="server" /></li>
                <li><asp:HyperLink NavigateUrl="Withdraw.aspx" Text="Withdraw" runat="server" /></li>
                <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
                <li><asp:HyperLink NavigateUrl="ContactAndSupport.aspx" Text="Contact and Support" runat="server" /></li>
            </ul>
        </div>

<div class="form-group" style="margin-top: 100px; margin-bottom: 50px;">
    <ul class="form-group-labels">
        <li><label for="lblLastPayment">Last Payment:</label></li>
        <li><label for="lblCurrentMinPayment">Current Minimum Payment:</label></li>
        <li><label for="lblOverLimitPayment">Over Limit Payment:</label></li>
        <li><label for="lblTotalPayment">Total Owed Balance:</label></li>
        <li><label for="lblDetailPayment">Detail Loan Transactions:</label></li>
    </ul>
</div>--%>


</asp:Content>