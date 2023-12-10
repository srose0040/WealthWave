<%@ Page Language="C#" Title="Saving Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavingAccount.aspx.cs"  Inherits="BankApplication1.ForgotPassword" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="text-center" style="margin-top: 50px; margin-bottom: 50px;">
 
        <h1 class="display-4">Saving Account [AccountNumber]</h1>
    </div>

    <div class="form-group "  style="margin-top: 100px; margin-bottom: 50px;">
        <label for="lblAccountNumber">Account Number:</label>
    <asp:Label ID="lblAccountNumber" runat="server" Text="123456789" />
    </div>

    <div>
        <label for="lblBalance">Balance:</label>
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
</asp:Content>
