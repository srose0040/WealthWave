<%@ Page Language="C#" Title="Loan Account" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SettingAndPrivacy.aspx" Inherits="BankApplication1.SettingAndPrivacy" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4">Setting And Privacy </h1>
    </div>

    <div>
        <!-- Embed PDF viewer using iframe -->
        <iframe src="SettingAndPrivacy.pdf" width="100%" height="600px"></iframe>
    </div>

    <!-- go back Submit Button -->
    <div class="form-group" style="margin-top: 50px;">
        <asp:Button ID="btnGoBack" CssClass="fancy-button primary-button" Text="Go Back" runat="server" class="btn btn-primary" OnClick="btnGoBack_Click" />
    </div>
        
</asp:Content>


