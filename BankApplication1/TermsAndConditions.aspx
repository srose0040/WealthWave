<%@ Page Language="C#" Title="Terms and Conditions" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="TermsAndConditions.aspx.cs" Inherits="BankApplication1.TermsAndConditions" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4"> User Terms and Conditions</h1>
    </div>

    <div>
          <!-- Embed PDF viewer using iframe -->
        <iframe src="Content/BankAgreement.pdf" width="100%" height="600px"></iframe>
    </div>
        
</asp:Content>

