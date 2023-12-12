<%@ Page Language="C#" Title="Savings Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavingAccount.aspx.cs"  Inherits="BankApplication1.SavingAccount" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h3 class="display-4">Saving Account </h3>
    </div>

     <div>
        <p>Account Number:  <%= Session["CustomerId"] %><%= Session["CustomerId"] %></p>
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
</div>

        <!-- Submit Button -->
<div class="form-group" style="margin-top: 50px;">
    <asp:Button ID="savingSubmitbtn" CssClass="fancy-button primary-button" Text="Submit" runat="server" class="btn btn-primary" OnClick="TransactionButton_Click" />
    <asp:Button ID="btnLogout" CssClass="fancy-button primary-button"  Text="Log Out" runat ="server"  class="btn btn-primary" OnClick="LogoutButton_Click" />
</div>

    <!--lbel for Error message-->
<div>
    <asp:Label ID="ShowMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
</div>
        
</asp:Content>
