<%@ Page Language="C#" Title="Savings Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavingAccount.aspx.cs"  Inherits="BankApplication1.SavingAccount" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4">Saving account page </h1>
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
        
</asp:Content>
