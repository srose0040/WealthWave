<%@ Page Language="C#" Title="Loan Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanAccount.aspx.cs" Inherits="BankApplication1.LoanAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<<<<<<< HEAD
    
    <div class="text-center" style= "margin-top: 50px;">
      <h3 class="display-4">Loan Account </h3>
    </div>

   <div>
      <p>Account Number:  <%= Session["CustomerId"] %><%= Session["CustomerId"] %></p>
   </div>

=======

    

    <div class="text-center">
        <h1 class="display-4">Loan Account||Account Number:  <%= Session["CustomerId"] %> </h1>
    </div>

>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
    
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="amount">Amount:</label>
        <asp:TextBox ID="amountTextBox" runat="server" CssClass="form-control" />
<<<<<<< HEAD
=======
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="balance">Balance To Pay Off:</label>
        <asp:TextBox ID="balanceTextBox" runat="server" CssClass="form-control" ReadOnly="true"/>
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
<<<<<<< HEAD
        <label for="balance">Balance To Pay Off:</label>
        <asp:TextBox ID="balanceTextBox" runat="server" CssClass="form-control" ReadOnly="true"/>
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
=======
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
        <label for="deposit">Pay Off Loan:</label>
        <asp:RadioButton ID="depositRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="withdraw">Apply For Loan:</label>
        <asp:RadioButton ID="withdrawRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>

        <!-- Submit Button -->
<div class="form-group" style="margin-top: 50px;">
    <asp:Button ID="savingSubmitbtn" CssClass="fancy-button primary-button" Text="Submit" runat="server" class="btn btn-primary" OnClick="TransactionButton_Click" />
    <asp:Button ID="btnLogout" CssClass="fancy-button primary-button"  Text="Log Out" runat ="server"  class="btn btn-primary" OnClick="LogoutButton_Click" />
</div>

    <!--lbel for Error message-->
<div>
    <asp:Label ID="ShowMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
<<<<<<< HEAD


        <div class="bodyTitles" style="position: absolute; top: 250px; right: 250px;">
        <h3>Go To:</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="AccountDetails.aspx" Text="Account Details" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Deposit to Savings" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ChequingAccount.aspx" Text="Deposit to Chequings" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ContactAndSupport.aspx" Text="Contact and Support" runat="server" /></li>
        </ul>
    </div>
=======
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
</div>











</asp:Content>