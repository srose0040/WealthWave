<%@ Page Language="C#" Title="Checking Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChequingAccount.aspx.cs" Inherits="BankApplication1.ChequingAccount" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center" style= "margin-top: 50px;">
        <h3 class="display-4">Chequing Account </h3>
    </div>

     <div>
        <p>Account Number:  <%= Session["CustomerId"] %><%= Session["CustomerId"] %></p>
     </div>

    
<!--Div for Amount -->    
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="amount">Amount:</label>
        <asp:TextBox ID="amountTextBox1" runat="server" CssClass="form-control" />
    </div>
</div>
<!--Div for Balance -->
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="balance">Current Balance:</label>
        <asp:TextBox ID="balanceTextBox" runat="server" CssClass="form-control" ReadOnly="true"/>
    </div>
</div>
<!--Div for Deposit -->
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="deposit">Deposit:</label>
        <asp:RadioButton ID="depositRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>
 <!--Div for Withdraw -->
<div class="col-md-6">
    <div class="form-group" style="margin-top: 50px;">
        <label for="withdraw">Withdraw:</label>
        <asp:RadioButton ID="withdrawRadioButton" runat="server" GroupName="TransactionType" />
    </div>
</div>
        <!-- Submit Button -->
<div class="form-group" style="margin-top: 50px;">
    <asp:Button ID="savingSubmitbtn" CssClass="fancy-button primary-button" Text="Submit" runat="server" class="btn btn-primary" OnClick="TransactionButton_Click" />
    <asp:Button ID="btnLogout" CssClass="fancy-button primary-button"  Text="Log Out" runat ="server"  class="btn btn-primary" OnClick="LogoutButton_Click" />
</div>

    <!--label for Error message-->
<div>
    <asp:Label ID="ShowMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
</div>
    <!--Div for Different options Links -->
    <div class="bodyTitles" style="position: absolute; top: 250px; right: 250px;">
        <h3>Go To:</h3>
        <ul>
            <li><asp:HyperLink NavigateUrl="AccountDetails.aspx" Text="Account Details" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SavingAccount.aspx" Text="Deposit to Savings" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="LoanAccount.aspx" Text="Pay off your Loan" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ContactAndSupport.aspx" Text="Contact and Support" runat="server" /></li>
        </ul>
    </div>
        
</asp:Content>