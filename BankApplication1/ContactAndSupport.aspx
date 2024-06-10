<%@ Page Language="C#" Title="Contact And Support " MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactAndSupport.aspx" Inherits="BankApplication1.ContactAndSupport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">
        <h1 class="display-4">Contact And Support page </h1>
    </div>
<!-- Link to the LinkedIn profile of the programmers -->

<div> 
    <h3> Programmers </h3>
</div>
<div>
    <a href="https://www.linkedin.com/in/ermiyas-gulti-4ab51521a/" target="_blank">Visit Ermiyas Gulti's LinkedIn Profile</a>
</div>

<div>
    <a href="https://www.linkedin.com/in/saje-antoine-rose/" target="_blank">Visit Sajé-Antoine Rose's LinkedIn Profile</a>
</div>




<!-- go back Submit Button -->
<div class="form-group" style="margin-top: 50px;">
    <asp:Button ID="btnGoBack" CssClass="fancy-button primary-button" Text="Go Back" runat="server" class="btn btn-primary" OnClick="btnGoBack_Click" />
</div>


        
</asp:Content>




