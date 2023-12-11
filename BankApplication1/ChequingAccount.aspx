<%@ Page Language="C#" Title="Checking Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChequingAccount.aspx.cs" Inherits="BankApplication1.ChequingAccount" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div class="text-center" style="margin-top: 50px; margin-bottom: 50px;">
 
     <h1 class="display-4">Chequing  Account [AccountNumber]</h1>
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

    <div class="fancy-buttons-container" style="margin-bottom: 200px; margin-top: 200px;">
        <asp:Button ID="lblTransaction" runat="server" CssClass="fancy-button primary-button" Text="Go to Transaction" OnClick="TransactionButton_Click" />
        <asp:Button ID="btnLogout" runat ="server" CssClass="fancy-button primary-button" Text="Log Out" OnClick="LogoutButton_Click" />
    </div>

    <!--lbel for Error message-->
<div>
    <asp:Label ID="ShowMessage" runat="server" ForeColor="Black" Text=""></asp:Label>
</div>



   <div class="bodyTitles" style="position: fixed; top: 300px; right: 100px;">
        <ul>
            <li><asp:HyperLink NavigateUrl="Deposit.aspx" Text="Deposit" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="Withdraw.aspx" Text="Withdraw" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="SettingAndPrivacy.aspx" Text="Setting and Privacy" runat="server" /></li>
            <li><asp:HyperLink NavigateUrl="ContactAndSupport.aspx" Text="Contact and Support" runat="server" /></li>
        </ul>
    </div>
        
</asp:Content>