<%@ Page Language="C#" Title="Terms and Conditions" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="TermsAndConditions.aspx.cs" Inherits="BankApplication1.TermsAndConditions" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4"> User Terms and Conditions</h1>
    </div>

     <div>
          <!-- Embed PDF viewer using iframe -->
        <iframe src="BankAgreement.pdf" width="100%" height="600px"></iframe>
    </div>

   <div class="submitButton" style="margin-bottom: 10px; margin-top: 10px;">
         <asp:Button ID="agreeButton" runat="server" Text="I have read the Term and conditon" OnClick="AgreeButton_Click"  style="width: auto; margin-top: 20px; margin-bottom: 20px; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white; background-color:darkblue; border: none; padding: 10px 20px;" />
    </div>
        
</asp:Content>

