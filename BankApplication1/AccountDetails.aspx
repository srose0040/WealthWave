
<%@ Page Language="C#" Title="Home Page" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="BankApplication1.AccountDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="text-left" style="margin-bottom: 75px; margin-top: 75px;">
    <h3>
        <asp:Label ID="lblAccountHolder" runat="server" CssClass="account-holder-label"></asp:Label>
    </h3>

</div>
    <!--Div for Customer Details -->
    <div class="customer-details" >
        <label for="lblCustomerId">Account Number:</label>
        <asp:Label ID="MainContent_lblCustomerId" runat="server" CssClass="label-value"></asp:Label>

    <!--Customer First Name -->
        <label for="lblFirstName">First Name:</label>
        <asp:Label ID="lblFirstName" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Last Name -->
        <label for="lblLastName">Last Name:</label>
        <asp:Label ID="lblLastName" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Date of Birth -->
        <label for="lblDateOfBirth">Date of Birth:</label>
        <asp:Label ID="lblDateOfBirth" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Gender -->
        <label for="lblSex">Sex:</label>
        <asp:Label ID="lblSex" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Phone Number -->
        <label for="lblPhoneNumber">Phone Number:</label>
        <asp:Label ID="lblPhoneNumber" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Address -->
        <label for="lblAddress">Address:</label>
        <asp:Label ID="lblAddress" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer CurrentBalance -->
        <label for="lblCurrentBalance">Current Balance:</label>
        <asp:Label ID="lblCurrentBalance" runat="server" CssClass="label-value" Text=""></asp:Label>
    <!--Customer Email -->
        <label for="lblEmail">Email:</label>
        <asp:Label ID="lblEmail" runat="server" CssClass="label-value" Text=""></asp:Label>

    </div>


      <!-- go back Submit Button -->
  <div class="form-group" style="margin-top: 50px;">
      <asp:Button ID="btnGoBack" CssClass="fancy-button primary-button" Text="Go Back" runat="server" class="btn btn-primary" OnClick="btnGoBack_Click" />
  </div>

</asp:Content>
