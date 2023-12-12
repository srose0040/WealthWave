<%@ Page Language="C#" Title="Contact And Support " MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactAndSupport.aspx" Inherits="BankApplication1.ContactAndSupport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4">Contact And Support page </h1>
    </div>
     <div>
          <!-- Embed PDF viewer using iframe -->
        <iframe src="ContactInformation.pdf" width="100%" height="600px"></iframe>
    </div>
        
</asp:Content>




